using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleArmUIOnLook : Raycaster
{

    private IEnumerator coroutine;

    protected override void OnRaycasterEnter(GameObject target)
    {
        coroutine = WaitToShowUI(target);
        StartCoroutine(coroutine);
    }

    protected override void OnRaycasterLeave(GameObject target)
    {
        coroutine = WaitToHideUI(target);
        StartCoroutine(coroutine);

    }

    IEnumerator WaitToShowUI(GameObject target)
    {
        yield return new WaitForSeconds(.2f);
        Debug.Log("HIT!");
        for (int i = 0; i < target.transform.childCount; i++)
            target.transform.GetChild(i).gameObject.SetActive(true);
        

    }
    IEnumerator WaitToHideUI(GameObject target)
    {
        yield return new WaitForSeconds(.5f);
        Debug.Log("LEAVE!");
        for (int i = 0; i < target.transform.childCount; i++)
            target.transform.GetChild(i).gameObject.SetActive(false);

    }





}