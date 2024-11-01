using UnityEngine;
using System.Collections.Generic;

public class Gate : MonoBehaviour{
    public virtual void updateGate(){

    }
    public List<GateInput> inputs = new List<GateInput>();
    public List<GateOutput> outputs = new List<GateOutput>();

    public void Init(){
        foreach(GateInput input in inputs){
            input.gate = this;
        }
        foreach(GateOutput output in outputs){
            output.gate = this;
        }
    }
}
