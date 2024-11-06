using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AND : Gate
{
    void Start(){
        base.gateName = "AND";
        base.Init();
    }

    public static byte ANDOperation(byte a, byte b){
        if(a == 1 && b == 1){
            return 1;
        }
        else{
            return 0;
        }
    }

    public override void updateGate()
    {
        byte result = ANDOperation(inputs[0].state, inputs[1].state);
        foreach(GateOutput output in outputs){
            output.sendSignal(result);
        }
    }
}
