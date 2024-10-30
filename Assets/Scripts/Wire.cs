using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    private int state = 0;
    private LineRenderer line;
    private GateInput wireOutput;
    public GateOutput wireInput;
    
    void Awake(){
        line = GetComponent<LineRenderer>();
    }
    public void setStartPoint(Vector2 pos){
        line.SetPosition(0, pos);
    }
    public void setEndPoint(Vector2 pos){
        line.SetPosition(1, pos);
    }
    public void setWireOutput(GateInput gateInput){
        wireOutput = gateInput;   
    }
    public void setWireInput(GateOutput gateOutput){
        wireInput = gateOutput;
    }

    public void sendSignal(int signal){
        wireOutput.state = signal;
        wireOutput.gate.updateGate();
    }
}
