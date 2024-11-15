using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBoxScript : MonoBehaviour
{
    public Vector2 spawnedWorldPosition;
    private GameManager gameManager;

    private void Start(){
        gameManager = FindObjectOfType<GameManager>();
    }


    public void CreateGate(int id){
        gameManager.CreateGate(id, spawnedWorldPosition);
    }

    public void AddSwitch(){
        gameManager.AddSwitch(spawnedWorldPosition);
    }
    public void AddOutput(){
        gameManager.AddOutput(spawnedWorldPosition);
    }
}
