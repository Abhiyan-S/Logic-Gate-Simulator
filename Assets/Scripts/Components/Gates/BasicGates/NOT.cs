using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOT : Gate
{
    public static byte NOTOperation(byte a){
        return (byte)(1 -a);
    }
    void Start()
    {
        base.gateName = "NOT";
        base.Init();
    }

    public override void updateGate(){
        byte result = NOTOperation(inputs[0].state);
        foreach(GateOutput output in outputs){
            output.sendSignal(result);
        }
    }
}
