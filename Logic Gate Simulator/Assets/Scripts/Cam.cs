using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private float sensitivity = 20f;
    [SerializeField] private float scrollSensitivity = 20f;
    float x,y;
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if(Input.GetMouseButton(2)){
            x = Input.GetAxis("Mouse X");
            y = Input.GetAxis("Mouse Y");

            Vector2 dir = new Vector2(-x,-y);
            transform.position = transform.position + (new Vector3(dir.x,dir.y, scroll * scrollSensitivity) * Time.deltaTime * sensitivity);
        }
    }
}
