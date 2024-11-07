using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicGatesUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    [SerializeField] private BasicGatesButton basicGatesButton;
    public bool mouseOver = false;

    public void OnPointerEnter(PointerEventData pointerData){
        mouseOver = true;
    }
    public void OnPointerExit(PointerEventData pointerData){
        mouseOver = false;
        StartCoroutine(basicGatesButton.SetBasicGatesVisibility(false));
    }
}
