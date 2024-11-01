using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOutput : MonoBehaviour
{
    private List<Wire> wires = new List<Wire>();
    public Gate gate;
    public int state = 0;
    public void sendSignal(int signal){//signal = 0,1
        state = signal;
        foreach(Wire wire in wires){
            wire.sendSignal(state);
        }
    }
    public void addWire(Wire wire){
        wires.Add(wire);
    }
}
