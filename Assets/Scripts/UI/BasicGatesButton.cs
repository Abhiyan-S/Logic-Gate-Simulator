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
            StartCoroutine(FadeInBasicGates());
        }
        else{
            if(!basicGatesUI.mouseOver){
                StartCoroutine(FadeOutBasicGates());
            }
        }
    }
    IEnumerator FadeInBasicGates(){
        basicGatesUI.gameObject.SetActive(true);
        CanvasGroup basicGates = basicGatesUI.GetComponent<CanvasGroup>();
        float alpha = 0;
        while(alpha <= 1){
            basicGates.alpha = alpha;
            alpha += 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator FadeOutBasicGates(){
        CanvasGroup basicGates = basicGatesUI.GetComponent<CanvasGroup>();
        float alpha = 1;
        while(alpha >= 0){
            basicGates.alpha = alpha;
            alpha -= 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        basicGatesUI.gameObject.SetActive(false);
    }
}
