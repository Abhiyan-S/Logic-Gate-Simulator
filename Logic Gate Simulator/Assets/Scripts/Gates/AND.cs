using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AND : MonoBehaviour, IGate
{
    // Start is called before the first frame update
    public GateInput[] inputs{get;set;}
    public GateInput[] outputs{get; set;}
    // Update is called once per frame
    public void updateGate()
    {
        if(inputs[0].state == 1 && inputs[1].state == 1){
            for(int i = 0; i<outputs.Length; i++){
                outputs[i].state = 1;
                outputs[i].gate.updateGate();
            }
        }
    }
}
