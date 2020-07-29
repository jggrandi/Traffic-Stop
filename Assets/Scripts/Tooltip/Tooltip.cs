using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;
using System;

public class Tooltip : MonoBehaviour
{
    public GameObject startPoint;

    protected Player player;
    protected GameObject line;
    protected GameObject textCanvas;
    protected Vector3 endPoint;
    protected Vector3 offset = new Vector3(.0f, -.25f, .3f);
    

    protected void InitalSetup()
    {
        player = Player.instance;
        line = this.transform.GetChild(0).GetChild(0).gameObject;
        //line.SetActive(false);
        textCanvas = this.transform.GetChild(0).GetChild(1).gameObject;
        //textCanvas.SetActive(false);
    }

    protected virtual void ShowTooltip(int _scanCode)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
    }

    protected virtual void HideTooltip()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
    }

    protected void SetTooltipText(string _text)
    {
        Text t = textCanvas.GetComponentInChildren<Text>();
        if (t == null) { Debug.Log("Text field not found"); return; }

        t.text = _text;
    }

    protected void MakeTheMagicHappen()
    {
        //Transform playerTransform = player.hmdTransform;
        //endPoint = playerTransform.position;// + offset;


        Vector3 distFromCamera = (player.hmdTransform.position + player.hmdTransform.forward * .8f);

        textCanvas.transform.position = distFromCamera;
        //textCanvas.transform.rotation = Quaternion.LookRotation(startPoint.transform.position - player.hmdTransform.position);

        textCanvas.transform.LookAt(player.hmdTransform);

        //textCanvas.transform.position = endPoint;
        //textCanvas.transform.rotation = Quaternion.identity;

        //Vector3 vDir = playerTransform.position - endPoint;

        //Quaternion standardLookat = Quaternion.LookRotation(vDir, Vector3.up);
        //Quaternion upsideDownLookat = Quaternion.LookRotation(vDir, playerTransform.up);

        //float flInterp;
        //if (playerTransform.forward.y > 0.0f)
        //{
        //    flInterp = Util.RemapNumberClamped(playerTransform.forward.y, 0.6f, 0.4f, 1.0f, 0.0f);
        //}
        //else
        //{
        //    flInterp = Util.RemapNumberClamped(playerTransform.forward.y, -0.8f, -0.6f, 1.0f, 0.0f);
        //}

        ////textCanvas.transform.rotation = Quaternion.Slerp(standardLookat, upsideDownLookat, flInterp);
        //textCanvas.transform.rotation = 

        Transform lineTransform = line.transform;
        LineRenderer lineR = line.GetComponent<LineRenderer>();
        lineR.useWorldSpace = false;
        lineR.SetPosition(0, lineTransform.InverseTransformPoint(startPoint.transform.position));
        lineR.SetPosition(1, lineTransform.InverseTransformPoint(distFromCamera));
    }


}
