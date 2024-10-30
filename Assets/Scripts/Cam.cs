using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private float sensitivity = 20f;
    [SerializeField] private float scrollSensitivity = 20f;
    [SerializeField] GameObject wireRef;
    private bool drawingLine = false;
    private Wire currentWire;
    private Camera cam;
    float x,y;
    void Start(){
        cam = GetComponent<Camera>();
    }
    void handleCamMovement(){
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        cam.orthographicSize -= scroll * scrollSensitivity * Time.deltaTime;
        if(Input.GetMouseButton(2)){
            x = Input.GetAxis("Mouse X");
            y = Input.GetAxis("Mouse Y");

            Vector2 dir = new Vector2(-x,-y);
            transform.position = transform.position + (new Vector3(dir.x,dir.y, 0) * Time.deltaTime * sensitivity);
        }
    }

    void detectGateOutput(){
        Vector2 start = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(start.ToString());
        //Ray cast from start too 0.01 unit up
        RaycastHit2D hit = Physics2D.Raycast(start, new Vector2(0,1), 0.01f);
        if(hit){
            GateOutput gateOutput;
            hit.transform.TryGetComponent<GateOutput>(out gateOutput);
            Debug.Log("Hit");
            if(gateOutput != null){
                Debug.Log("Hit output");
                currentWire = Instantiate(wireRef, gateOutput.transform.position, Quaternion.identity).GetComponent<Wire>();
                currentWire.setStartPoint(gateOutput.transform.position);
                currentWire.setWireInput(gateOutput);
                drawingLine = true;
            }
        }
    }
    private void drawWire(){
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentWire.setEndPoint(currentPos);

        if(Input.GetMouseButtonUp(0)){ 
            drawingLine = false;
            RaycastHit2D hit = Physics2D.Raycast(currentPos, new Vector2(0,1), 0.01f);
            if(hit){
                GateInput gateInput;
                hit.transform.TryGetComponent<GateInput>(out gateInput);
                if(gateInput == null){
                    Destroy(currentWire.gameObject);
                    currentWire = null;
                }
                else{
                    currentWire.setEndPoint(gateInput.transform.position);
                    currentWire.setWireOutput(gateInput);
                    Debug.Log("Output set to "+gateInput.name);
                    currentWire.wireInput.addWire(currentWire);
                }
            }
            else{
                Destroy(currentWire.gameObject);
                currentWire = null;
            }
        }
    }
    void Update()
    {
        handleCamMovement();
        if(Input.GetMouseButtonDown(0)){
            detectGateOutput();
        }
        if(drawingLine){
            drawWire();
        }
    }
}
