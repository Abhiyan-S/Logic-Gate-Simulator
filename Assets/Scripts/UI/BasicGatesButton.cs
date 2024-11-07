using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicGatesButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private BasicGatesUI basicGatesUI;

    public void OnPointerEnter(PointerEventData pointerData){
        StartCoroutine(SetBasicGatesVisibility(true));
    }
    public void OnPointerExit(PointerEventData pointerData){
        StartCoroutine(SetBasicGatesVisibility(false));
    }
    public IEnumerator SetBasicGatesVisibility(bool visible){
        yield return new WaitForSeconds(.1f);
        if(visible){
            basicGatesUI.gameObject.SetActive(true);
        }
        else{
            if(!basicGatesUI.mouseOver){
                basicGatesUI.gameObject.SetActive(false);
            }
        }
    }
}
