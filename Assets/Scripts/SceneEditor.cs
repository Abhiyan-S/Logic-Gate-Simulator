using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEditor : MonoBehaviour
{
    private Camera cam;
    [SerializeField] GameObject wireRef;
    private bool drawingLine = false;
    private bool movingObj = false;
    private Vector2 selectionOffset;
    private Wire currentWire;
    private Transform selectedObj;
    private Transform highlightedSprite;
    void detectGateOutput(Vector2 pos){
        //Ray cast from start too 0.01 unit up
        RaycastHit2D hit = Physics2D.Raycast(pos, new Vector2(0,1), 0.01f);
        if(!hit){ return;}
        
        GateOutput gateOutput;
        hit.transform.TryGetComponent<GateOutput>(out gateOutput);

        if(gateOutput != null){

            currentWire = Instantiate(wireRef, gateOutput.transform.position, Quaternion.identity).GetComponent<Wire>();
            currentWire.setStartPoint(gateOutput.transform.position);
            currentWire.setWireInput(gateOutput);
            drawingLine = true;
        }
        
    }
    private void drawWire(){
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
            else{
                currentWire.setEndPoint(gateInput.transform.position);
                currentWire.setWireOutput(gateInput);
                currentWire.wireInput.addWire(currentWire);
            
            }
        }
    }
    private void highlight(Transform obj){
        if(highlightedSprite){Destroy(highlightedSprite.gameObject); }//Destroy last selected highlighted sprite of there is

        //Instantiaing the highlighted sprite
        highlightedSprite = new GameObject("Highlighted").transform;
        highlightedSprite.position = Vector2.zero;
        highlightedSprite.SetParent(obj);
        highlightedSprite.localPosition = Vector2.zero;
        //modifying the highlight
        SpriteRenderer sprite = highlightedSprite.gameObject.AddComponent<SpriteRenderer>();
        sprite.sprite = obj.GetComponent<SpriteRenderer>().sprite;
        sprite.color = new Color(.9f,.9f,.9f,.8f);
        sprite.sortingOrder=-1;
        highlightedSprite.localScale = new Vector2(1.1f,1.1f);
        
    }
    private void select(Vector2 pos){
        RaycastHit2D hit = Physics2D.Raycast(pos, new Vector2(0,1), 0.01f);
        if(!hit){ Debug.Log("No hit");return;}
        if(hit.transform.CompareTag("Selectable")){
            selectedObj = hit.transform;
            selectionOffset = pos - new Vector2(hit.transform.position.x, hit.transform.position.y);
            movingObj = true;
            highlight(selectedObj);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            detectGateOutput(pos);
            select(pos);
        }
        if(drawingLine){
            drawWire();
        }
        if(movingObj){
            Vector2 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
            selectedObj.position = newPos - selectionOffset;
        }
        if(Input.GetMouseButtonUp(0)){
            movingObj = false;
        }
    }
}
