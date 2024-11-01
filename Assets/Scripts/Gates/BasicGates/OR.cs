using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OR : Gate
{
    [SerializeField] private GateInput[] inputsToAdd;
    [SerializeField] private GateOutput[] outputsToAdd;
    public static int OROperation(int a, int b){
        if(a == 1 || b == 1){ return 1;}
        else{return 0;}
    }
    void Start()
    {
        base.Init();
    }

    public override void updateGate(){
        int result = OROperation(inputs[0].state, inputs[1].state);
        foreach(GateOutput output in outputs){
            output.sendSignal(result);
        }
    }
}
