using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneEditor : MonoBehaviour
{
    private Camera cam;
    private GameManager gameManager;
    [Header("Wire")]
    private bool drawingLine = false;
    private Wire currentWire;
    [SerializeField] private GameObject wireRef;
    [Header("UI")]
    [SerializeField] private Transform UICanvas;
    [SerializeField] private Transform toolBoxRefrence;
    public Transform toolBox;
    [Header("Selection")]
    private bool movingObj = false;
    private Vector3 selectionOffset;
    private ISelectable selectedObj;
    private Transform highlightedSprite;
    void detectGateOutput(Vector2 pos){
        //Ray cast from start too 0.01 unit up
        RaycastHit2D hit = Physics2D.Raycast(pos, new Vector2(0,1), 0.01f);
        if(!hit){ return;}
        
        GateOutput gateOutput;
        hit.transform.TryGetComponent<GateOutput>(out gateOutput);

        if(gateOutput != null){

            currentWire = Instantiate(wireRef, Vector2.zero, Quaternion.identity).GetComponent<Wire>();
            currentWire.setStartPoint(gateOutput.transform.position);
            currentWire.setWireInput(gateOutput);
            drawingLine = true;
        }
        
    }
    private void DrawWire(){
        Vector2 currentPos = cam.ScreenToWorldPoint(Input.mousePosition);
        currentWire.setEndPoint(currentPos);

        if(Input.GetMouseButtonUp(0)){ 
            drawingLine = false;
            RaycastHit2D hit = Physics2D.Raycast(currentPos, new Vector2(0,1), 0.01f);
            if(!hit){
                Destroy(currentWire.gameObject);
                currentWire = null;
                return;
            }
            GateInput gateInput;
            hit.transform.TryGetComponent<GateInput>(out gateInput);
            if(gateInput == null){
                Destroy(currentWire.gameObject);
                currentWire = null;
            }
            if(gateInput.wire != null){// Discard if the input is already connected with a wire
                Destroy(currentWire.gameObject);
                currentWire = null;
            }
            else{
                currentWire.setEndPoint(gateInput.transform.position);
                currentWire.setWireOutput(gateInput);
                currentWire.wireInput.addWire(currentWire);
                gateInput.wire = currentWire;
                currentWire.UpdateCollider();
            }
        }
    }
    private void highlight(Transform obj){
        if(highlightedSprite){Destroy(highlightedSprite.gameObject); }//Destroy last selected highlighted sprite of there is

        //Instantiaing the highlighted sprite
        highlightedSprite = new GameObject("Highlighted").transform;
        highlightedSprite.position = obj.position;
        highlightedSprite.rotation = obj.rotation;
        highlightedSprite.SetParent(obj);
        highlightedSprite.localPosition = Vector2.zero;
        //modifying the highlight
        SpriteRenderer sprite = highlightedSprite.gameObject.AddComponent<SpriteRenderer>();
        sprite.sprite = obj.transform.GetComponent<SpriteRenderer>().sprite;
        sprite.color = new Color(.9f,.9f,.9f,.8f);
        sprite.sortingOrder=-1;
        highlightedSprite.localScale = new Vector2(1.1f,1.1f);
        
    }

    private void CheckForWire(Transform obj, Vector2 pos){
        Wire wire;
        if(obj.TryGetComponent<Wire>(out wire)){
            WireKnob knob =  wire.AddPoint(pos);
            selectedObj = knob.GetComponent<ISelectable>();
            highlight(knob.transform);
            movingObj = true;
        }
    }
    private void select(Vector2 pos){
        RaycastHit2D hit = Physics2D.Raycast(pos, new Vector2(0,1), 0.01f);
        if(!hit){ return;}

        hit.transform.TryGetComponent<ISelectable>(out selectedObj);
        if(selectedObj == null){
            CheckForWire(hit.transform, pos);
            return;
        }
        selectionOffset = pos - new Vector2(hit.transform.position.x, hit.transform.position.y);
        movingObj = true;
        highlight(hit.transform);
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void HandleSelectedMovement(){
        if(movingObj){
            Vector3 newPos = cam.ScreenToWorldPoint(Input.mousePosition) - selectionOffset;
            selectedObj.move(newPos);
        }
        if(Input.GetMouseButtonUp(0)){
            movingObj = false;
            selectionOffset = Vector2.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
            if(toolBox){
                Destroy(toolBox.gameObject);
            }
            Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            detectGateOutput(pos);
            select(pos);
        }
        if(Input.GetMouseButtonDown(1)){
            Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, new Vector2(0,1), 0.01f);

            if(!hit){
                if(toolBox){ Destroy(toolBox.gameObject); }
                toolBox = Instantiate(toolBoxRefrence, Input.mousePosition, Quaternion.identity, UICanvas);
                toolBox.GetComponent<ToolBoxScript>().spawnedWorldPosition = pos;
                StartCoroutine(FadeInToolBox(toolBox.GetComponent<CanvasGroup>()));
            }
        }


        if(drawingLine){
            DrawWire();
        }
        HandleSelectedMovement();
    }

    IEnumerator FadeInToolBox(CanvasGroup toolBox){
        float alpha = 0;
        while(alpha <= 1){
            toolBox.alpha = alpha;
            alpha += 0.05f;
            yield return new WaitForSeconds(0.005f);
        }
    }
}
