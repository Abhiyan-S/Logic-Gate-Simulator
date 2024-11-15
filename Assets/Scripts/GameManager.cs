using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Gates")]
    [SerializeField] private Transform NOTGate;// id = 0
    [SerializeField] private Transform ANDGate;// id = 1
    [SerializeField] private Transform ORGate;// id = 2
    [SerializeField] private Transform XORGate;// id = 3
    [SerializeField] private Transform NANDGate;// id = 4
    [SerializeField] private Transform NORGate;// id = 5
    [SerializeField] private Transform NXORGate;//id = 6

    private Transform[] gatesReference;
    [Header("Input")]
    
    [SerializeField] private Transform toggleSwitch;
    [Header("Output")]
    [SerializeField] private Transform output;
    private SceneEditor sceneEditor;
    void Start()
    {
        sceneEditor = GetComponent<SceneEditor>(); //GameManager and SceneEditor should be in the same script
        gatesReference = new Transform[] {NOTGate, ANDGate, ORGate, XORGate, NANDGate, NORGate, NXORGate};
    }

    public void CreateGate(int id, Vector2 pos){
        Instantiate(gatesReference[id], pos, gatesReference[id].rotation);

        Destroy(sceneEditor.toolBox.gameObject);
    }

    public void AddSwitch(Vector2 pos){
        Instantiate(toggleSwitch, pos, toggleSwitch.rotation);
        Destroy(sceneEditor.toolBox.gameObject);
    }

    public void AddOutput(Vector2 pos){
        Instantiate(output, pos, output.rotation);
        Destroy(sceneEditor.toolBox.gameObject);
    }
}
