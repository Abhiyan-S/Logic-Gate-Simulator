using UnityEngine;

public class WiresParent : MonoBehaviour
{
    public Wire startWire;
    public Wire endWire;

    public void DeleteWire(){
        startWire.wireInput.wires.Remove(startWire);
        endWire.wireOutput.state = 0;
        endWire.wireOutput.gate.updateGate();
        endWire.wireOutput.wire = null;

        Destroy(gameObject);
    }
}
