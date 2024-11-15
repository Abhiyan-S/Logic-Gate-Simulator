public class NOR : Gate
{
    public static byte NOROperation(byte a, byte b){
        if(a == 1 || b == 1){
            return 0;
        }
        else{
            return 1;
        }
    }
    void Start()
    {
        base.gateName = "NOR";
        base.Init();
    }

    public override void updateGate(){
        byte result = NOROperation(inputs[0].state, inputs[1].state);
        foreach(GateOutput output in outputs){
            output.sendSignal(result);
        }
    }
}
