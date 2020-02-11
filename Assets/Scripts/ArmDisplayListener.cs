using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ArmDisplayListener : MonoBehaviour
{
    CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        ToggleArmUIOnLook.TriggerArmDisplay += ShowArmDisplay;
        ToggleArmUIOnLook.HideArmDisplay += HideDisplay;

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            Debug.LogError("Missing component Canvas Group");
        canvasGroup.alpha = 0f;
    }

    private void OnDisable()
    {
        ToggleArmUIOnLook.TriggerArmDisplay -= ShowArmDisplay;
        ToggleArmUIOnLook.HideArmDisplay -= HideDisplay;

    }

    void ShowArmDisplay()
    {
        //for (int i = 0; i < gameObject.transform.childCount; i++)
        //    gameObject.transform.GetChild(i).gameObject.SetActive(true);
        canvasGroup.LeanAlpha(1, 1f);
        canvasGroup.interactable = true;
    }

    void HideDisplay()
    {
        canvasGroup.LeanAlpha(0, 3f);
        canvasGroup.interactable = false;
        //for (int i = 0; i < gameObject.transform.childCount; i++)
        //    gameObject.transform.GetChild(i).gameObject.SetActive(false);
    }

}
