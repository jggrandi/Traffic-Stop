using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleArmUIOnLook : Raycaster
{

    public delegate void OnLookAtArm();
    public static OnLookAtArm TriggerArmDisplay;
    public static OnLookAtArm HideArmDisplay;

    private IEnumerator coroutine;

    protected override void OnRaycasterEnter(GameObject target)
    {
        if (target.gameObject.name == "AttachToArm")
        {
            Debug.Log("ArmDisplayTriggered");
            coroutine = WaitToShowUI(target);
            StartCoroutine(coroutine);
        }
    }

    protected override void OnRaycasterLeave(GameObject target)
    {
        if (target.gameObject.name == "AttachToArm")
        {
            coroutine = WaitToHideUI(target);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator WaitToShowUI(GameObject target)
    {
        yield return new WaitForSeconds(.2f);
        TriggerArmDisplay();
    }

    IEnumerator WaitToHideUI(GameObject target)
    {
        yield return new WaitForSeconds(.5f);
        HideArmDisplay();
    }





}