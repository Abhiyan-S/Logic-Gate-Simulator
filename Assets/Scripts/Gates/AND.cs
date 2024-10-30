using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AND : MonoBehaviour, IGate
{
    public List<GateInput> inputs { get; set; } = new List<GateInput>();
    public List<GateOutput> outputs { get; set; } = new List<GateOutput>();

    public GateInput[] inputsToAdd;
    public GateOutput[] outputsToAdd;
    void Start(){
        foreach(GateInput gateInput in inputsToAdd){
            gateInput.gate = this;
            inputs.Add(gateInput);
        }
        
        foreach(GateOutput gateOutput in outputsToAdd){
            outputs.Add(gateOutput);
        }
    }

    public void updateGate()
    {
        if(inputs[0].state == 1 && inputs[1].state == 1){
            foreach(GateOutput output in outputs){
                output.sendSignal(1);
            }
        }
        else{
            foreach(GateOutput output in outputs){
                output.sendSignal(0);
            }
        }
    }
}
