using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OR : Gate
{
    public static byte OROperation(byte a, byte b){
        if(a == 1 || b == 1){
            return 1;
        }
        else{
            return 0;
        }
    }
    void Start()
    {
        base.gateName = "OR";
        base.Init();
    }

    public override void updateGate(){
        byte result = OROperation(inputs[0].state, inputs[1].state);
        foreach(GateOutput output in outputs){
            output.sendSignal(result);
        }
    }
}
