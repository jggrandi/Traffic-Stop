using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(CanvasGroup))]
public class ArmDisplayListener : MonoBehaviour
{
    Player player;
    CanvasGroup canvasGroup;
    GameObject puck;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
        puck = this.transform.parent.gameObject;
        //ToggleArmUIOnLook.TriggerArmDisplay += ShowArmDisplay;
        //ToggleArmUIOnLook.HideArmDisplay += HideDisplay;

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            Debug.LogError("Missing component Canvas Group");
        canvasGroup.alpha = 0f;
    }

    //private void OnDisable()
    //{
    //    ToggleArmUIOnLook.TriggerArmDisplay -= ShowArmDisplay;
    //    ToggleArmUIOnLook.HideArmDisplay -= HideDisplay;

    //}

    float angle;
    static float ANGLE_MAX = 10f;

    private void Update()
    {
        angle = Vector3.Angle(player.hmdTransform.position + player.hmdTransform.forward, transform.parent.transform.position - transform.parent.transform.up);

        canvasGroup.alpha = Scale(0, ANGLE_MAX, 1, 0, angle);
        
        if(canvasGroup.alpha <= 0.3f) canvasGroup.interactable = false;
        else canvasGroup.interactable = true;
    }


    float Scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }

    //void ShowArmDisplay()
    //{
    //    //for (int i = 0; i < gameObject.transform.childCount; i++)
    //    //    gameObject.transform.GetChild(i).gameObject.SetActive(true);
    //    canvasGroup.LeanAlpha(1, 1f);
    //    canvasGroup.interactable = true;
    //}

    //void HideDisplay()
    //{
    //    canvasGroup.LeanAlpha(0, 3f);
    //    canvasGroup.interactable = false;
    //    //for (int i = 0; i < gameObject.transform.childCount; i++)
    //    //    gameObject.transform.GetChild(i).gameObject.SetActive(false);
    //}

}
