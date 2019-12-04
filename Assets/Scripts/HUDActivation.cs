using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDActivation : Raycaster
{

    private IEnumerator coroutine;

    public GameObject objTriggered;

    protected override void OnRaycasterEnter(GameObject target)
    {
        objTriggered = target;
        Debug.Log("DANNNMKKHUIHUIO!");
    }

    //protected override void OnRaycasterLeave(GameObject target)
    //{
    //    coroutine = WaitToHideUI(target);
    //    StartCoroutine(coroutine);

    //}

    //IEnumerator WaitToShowUI(GameObject target)
    //{


    //}
    //IEnumerator WaitToHideUI(GameObject target)
    //{
    //    yield return new WaitForSeconds(.5f);
    //    Debug.Log("LEAVE!");
    //    for (int i = 0; i < target.transform.childCount; i++)
    //        target.transform.GetChild(i).gameObject.SetActive(false);

    //}









}