using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOutput : MonoBehaviour
{
    private List<Wire> wires = new List<Wire>();
    public void sendSignal(int signal){//signal = 0,1
        foreach(Wire wire in wires){
            wire.sendSignal(signal);
        }
    }
    public void addWire(Wire wire){
        wires.Add(wire);
    }
}
