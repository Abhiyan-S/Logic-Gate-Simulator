using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulb : Gate
{

    [SerializeField] private GateInput input;
    private SpriteRenderer sprite;

    Color onColor = Color.blue;
    Color offColor = new Color(0f,0f,30f/255f,1.0f);
    void Start(){
        inputs.Add(input);
        inputs[0].gate = this;
        sprite = GetComponent<SpriteRenderer>();
    }
    public override void updateGate(){
        if(input.state == 1){
            sprite.color = onColor;
        }
        else{
            sprite.color = offColor;
        }
    }
}
