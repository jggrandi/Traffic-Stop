using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class TriggerTakeAction : MonoBehaviour
{
    public static Action OnTakeActionEnter;
    //public static Action OnTakeActionExit;

    static public bool isTriggered = false;

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.hmdTransform.position - transform.up * 0.3f;
        //Debug.Log(isTriggered);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (isTriggered) return;
        
        OnTakeActionEnter();
        isTriggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //isTriggered = false;
    }


}
