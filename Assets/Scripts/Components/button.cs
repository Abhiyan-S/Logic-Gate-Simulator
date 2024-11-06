using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour, ISelectable
{
    [SerializeField] private List <GateOutput> outputs = new List<GateOutput>();
    private byte state{get; set;} = 0;
    [SerializeField] private SpriteRenderer buttonSprite;
    [SerializeField] private Color onColor;
    [SerializeField] private Color offColor;
    // Update is called once per frame
    void Start(){
        buttonSprite = GetComponent<SpriteRenderer>();
    }
    
    public void OnMouseDown()
    {
        if(state == 0){
            state = 1;
            buttonSprite.color = onColor;
        }
        else{
            state = 0;
            buttonSprite.color = offColor;
        }

        foreach(GateOutput output in outputs){
            output.sendSignal(state);
        }
    }
    public void move(Vector2 newPos){
        transform.position = newPos;
        foreach(Wire wire in outputs[0].getWires()){
            wire.setStartPoint(outputs[0].transform.position);
            wire.UpdateCollider();
        }
    }
}
