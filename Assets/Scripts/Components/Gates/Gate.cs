using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Gate : MonoBehaviour, ISelectable
{
    public string gateName;
    [SerializeField] private TMP_Text nameLabel;
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
        if(nameLabel){
            nameLabel.text = gateName;
        }
    }
    public void move(Vector2 newPos){
        transform.position = newPos;
        foreach(GateInput input in inputs){
            if(input.wire){
                input.wire.setEndPoint(input.transform.position);
                input.wire.UpdateCollider();
            }
        }
        foreach(GateOutput output in outputs){
            foreach(Wire wire in output.getWires()){
                wire.setStartPoint(output.transform.position);
                wire.UpdateCollider();
            }
        }
    }
}
