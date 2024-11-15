using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour, ISelectable
{
    [SerializeField] GateOutput output;
    private byte state{get; set;} = 0;
    [SerializeField] private SpriteRenderer buttonSprite;
    [SerializeField] private Color onColor;
    [SerializeField] private Color offColor;
    
    private bool canToggle;
    void Start(){
        buttonSprite = GetComponent<SpriteRenderer>();
    }
    private void Toggle(){
        if(state == 0){
            state = 1;
            buttonSprite.color = onColor;
        }
        else{
            state = 0;
            buttonSprite.color = offColor;
        }

        output.sendSignal(state);
    }
    
    private void OnMouseDown()
    {
        canToggle = true;
    }
    private void OnMouseUp(){
        if(canToggle){
            Toggle();
        }
    }
    public void move(Vector2 newPos){
        Vector2 oldPos = transform.position;
        transform.position = newPos;

        if(Vector2.Distance(oldPos, newPos) >= 0.02f){
            canToggle = false;
        }
        foreach(Wire wire in output.wires){
            wire.setStartPoint(output.transform.position);
            wire.UpdateCollider();
        }
    }

    public void Delete(){
        foreach(Wire wire in output.wires){
            wire.DeleteWire();
        }
        Destroy(gameObject);
    }
}
