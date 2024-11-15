public class XOR : Gate
{
    void Start(){
        base.gateName = "XOR";
        base.Init();
    }

    public static byte XOROperation(byte a, byte b){
        if(a == 1 && b == 0 || a == 0 && b == 1){
            return 1;
        }
        else{
            return 0;
        }
    }

    public override void updateGate()
    {
        byte result = XOROperation(inputs[0].state, inputs[1].state);
        foreach(GateOutput output in outputs){
            output.sendSignal(result);
        }
    }
}
