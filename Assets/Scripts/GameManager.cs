using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform NOTGate;
    [SerializeField] private Transform ANDGate;
    [SerializeField] private Transform ORGate;
    void Start()
    {
        
    }

    public void CreateGate(int id, Vector2 pos){
        if(id == 0){
            Instantiate(NOTGate, pos, Quaternion.identity);
        }
        else if(id == 1){
            Instantiate(ANDGate, pos, Quaternion.identity);
        }
        else if(id == 2){
            Instantiate(ORGate, pos, Quaternion.identity);
        }
    }
}
