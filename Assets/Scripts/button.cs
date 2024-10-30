using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    [SerializeField] private List <GateOutput> outputs = new List<GateOutput>();
    private int state{get; set;} = 0;
    [SerializeField] private SpriteRenderer buttonSprite;
    // Update is called once per frame
    void Start(){
        buttonSprite = GetComponent<SpriteRenderer>();
    }
    
    public void OnMouseDown()
    {
        if(state == 0){
            state = 1;
            buttonSprite.color = Color.blue;
        }
        else{
            state = 0;
            buttonSprite.color = Color.red;
        }

        foreach(GateOutput output in outputs){
            output.sendSignal(state);
        }
    }
}
