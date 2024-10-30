using System;
using System.Collections.Generic;
public interface IGate{
    public void updateGate();
    List<GateInput> inputs { get; set; }
    List<GateOutput> outputs { get; set; }

}

