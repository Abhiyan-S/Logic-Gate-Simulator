using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    private int state = 0;
    private LineRenderer line;
    private GateInput wireOutput;
    public GateOutput wireInput;
    [SerializeField] private Color onStartColor;
    [SerializeField] private Color onEndColor;
    [SerializeField] private Color offStartColor;
    [SerializeField] private Color offEndColor;
    
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
        sendSignal(wireInput.state);
    }
    public void setWireInput(GateOutput gateOutput){
        wireInput = gateOutput;
    }

    public void sendSignal(int signal){
        if(signal == 1){
            line.startColor = onStartColor;
            line.endColor = onEndColor;
        }
        else{
            line.startColor = offStartColor;
            line.endColor = offEndColor;
        }
        wireOutput.state = signal;
        wireOutput.gate.updateGate();
    }
}
