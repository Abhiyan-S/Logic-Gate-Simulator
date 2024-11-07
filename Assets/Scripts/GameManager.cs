using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform NOTGate;// id = 0
    [SerializeField] private Transform ANDGate;// id = 1
    [SerializeField] private Transform ORGate;// id = 2
    
    private SceneEditor sceneEditor;
    void Start()
    {
        sceneEditor = GetComponent<SceneEditor>(); //GameManager and SceneEditor should be in the same script
    }

    public void CreateGate(int id, Vector2 pos){
        if(id == 0){
            Instantiate(NOTGate, pos, NOTGate.transform.rotation);
        }
        else if(id == 1){
            Instantiate(ANDGate, pos, ANDGate.transform.rotation);
        }
        else if(id == 2){
            Instantiate(ORGate, pos, ORGate.transform.rotation);
        }

        Destroy(sceneEditor.toolBox.gameObject);
    }
}
