using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    private int state = 0;
    [SerializeField] private Transform wireKnobReference;
    private LineRenderer line;
    public GateInput wireOutput;
    public GateOutput wireInput;
    public WireKnob inputKnob;
    public WireKnob outputKnob;
    [SerializeField] private Color onStartColor;
    [SerializeField] private Color onEndColor;
    [SerializeField] private Color offStartColor;
    [SerializeField] private Color offEndColor;
    private EdgeCollider2D edgeCollider;
    
    void Awake(){
        line = GetComponent<LineRenderer>();

        edgeCollider = GetComponent<EdgeCollider2D>();
    }
    public void UpdateCollider(){

        Vector3[] positions = new Vector3[line.positionCount];
        line.GetPositions(positions);

        Vector2[] colliderPoints = new Vector2[positions.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            colliderPoints[i] = new Vector2(positions[i].x, positions[i].y);
        }

        edgeCollider.SetPoints(new List<Vector2>(colliderPoints));

    }
    public void setStartPoint(Vector2 pos){
        line.SetPosition(0, pos);
    }
    public void setEndPoint(Vector2 pos){
        line.SetPosition(line.positionCount-1, pos);
    }
    public void setWireOutput(GateInput gateInput){
        wireOutput = gateInput;
        sendSignal((byte)wireInput.state);
    }
    public void setWireInput(GateOutput gateOutput){
        wireInput = gateOutput;
    }
    public void MovePoint(int index, Vector2 pos){
        line.SetPosition(index, pos);
        UpdateCollider();
    }

    public void sendSignal(byte signal){
        if(signal == 1){
            line.startColor = onStartColor;
            line.endColor = onEndColor;
        }
        else{
            line.startColor = offStartColor;
            line.endColor = offEndColor;
        }
        if(wireOutput != null){
            wireOutput.state = signal;
            wireOutput.gate.updateGate();
        }else if(outputKnob != null){
            outputKnob.sendSignal(signal);
        }
    }
    public WireKnob AddPoint(Vector2 pos){
        WireKnob knob = Instantiate(wireKnobReference, new Vector3(pos.x, pos.y, -0.1f), Quaternion.identity).GetComponent<WireKnob>();
        Wire newWire = Instantiate(gameObject, Vector3.zero, Quaternion.identity).GetComponent<Wire>();

        setEndPoint(pos);
        newWire.setStartPoint(pos);

        if(wireOutput != null){
            newWire.wireOutput = wireOutput;
            wireOutput.wire = newWire;
        }
        else{
            newWire.outputKnob = outputKnob;
        }

        this.outputKnob = knob;
        newWire.inputKnob = knob;

        this.wireOutput = null;
        newWire.wireInput = null;

        knob.SetWires(this, newWire);

        return knob;
    }
}
