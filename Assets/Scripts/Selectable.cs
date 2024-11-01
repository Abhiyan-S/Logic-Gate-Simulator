using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISelectable{
    void select();
    void highlight();
    void move(Vector2 newPos);
}
public class Selectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
