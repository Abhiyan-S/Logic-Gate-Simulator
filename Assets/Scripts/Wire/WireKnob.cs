using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireKnob : MonoBehaviour, ISelectable
{
    // Start is called before the first frame update
    private int index;
    private Wire inputWire;
    private Wire outputWire;

    public void SetWires(Wire input, Wire output){
        inputWire = input;
        outputWire = output;
    }
    public void move(Vector2 pos){
        transform.position = new Vector3(pos.x, pos.y, -0.1f);
        inputWire.setEndPoint(pos);
        outputWire.setStartPoint(pos);

        inputWire.UpdateCollider();
        outputWire.UpdateCollider();
    }
    public void sendSignal(byte signal){
        outputWire.sendSignal(signal);
    }

    public void Delete(){
        
    }
}
