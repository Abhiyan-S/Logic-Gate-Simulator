public class NXOR : Gate
{
    void Start(){
        base.gateName = "XOR";
        base.Init();
    }

    public static byte NXOROperation(byte a, byte b){
        if(a == 1 && b == 0 || a == 0 && b == 1){
            return 0;
        }
        else{
            return 1;
        }
    }

    public override void updateGate()
    {
        byte result = NXOROperation(inputs[0].state, inputs[1].state);
        foreach(GateOutput output in outputs){
            output.sendSignal(result);
        }
    }
}
