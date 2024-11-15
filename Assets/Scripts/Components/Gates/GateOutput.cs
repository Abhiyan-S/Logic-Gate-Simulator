using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOutput : MonoBehaviour
{
    public List<Wire> wires = new List<Wire>();
    public Gate gate;
    public byte state = 0;
    public void sendSignal(byte signal){//signal = 0,1
        state = signal;
        foreach(Wire wire in wires){
            wire.sendSignal(state);
        }
    }
    public void addWire(Wire wire){
        wires.Add(wire);
    }
}
