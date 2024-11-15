public class NAND : Gate
{
    void Start(){
        base.gateName = "NAND";
        base.Init();
    }

    public static byte NANDOperation(byte a, byte b){
        if(a == 1 && b == 1){
            return 0;
        }
        else{
            return 1;
        }
    }

    public override void updateGate()
    {
        byte result = NANDOperation(inputs[0].state, inputs[1].state);
        foreach(GateOutput output in outputs){
            output.sendSignal(result);
        }
    }
}
