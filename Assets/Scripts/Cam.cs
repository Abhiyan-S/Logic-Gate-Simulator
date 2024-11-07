using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private float sensitivity = 20f;
    [SerializeField] private float scrollSensitivity = 20f;
    private Camera cam;
    private SceneEditor sceneEditor;
    float x,y;
    void Start(){
        cam = GetComponent<Camera>();
        sceneEditor = FindObjectOfType<SceneEditor>();
    }
    void handleCamMovement(){
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        cam.orthographicSize -= scroll * scrollSensitivity * Time.deltaTime * cam.orthographicSize * 0.1f; //It zooms depending on the current zoomed out amount. .1 is constant to make the scroll factor smaller
        if(Input.GetMouseButton(2)){
            x = Input.GetAxis("Mouse X");
            y = Input.GetAxis("Mouse Y");

            Vector2 dir = new Vector2(-x,-y);
            transform.position = transform.position + (new Vector3(dir.x,dir.y, 0) * Time.deltaTime * sensitivity * cam.orthographicSize*0.1f);

            //Delete the tool box on middle mouse click
            Transform toolBox = sceneEditor.toolBox;
            if(toolBox){
                Destroy(toolBox.gameObject);
            }
        }
    }

    void Update()
    {
        handleCamMovement();
    }
}
