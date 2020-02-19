using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;
using System;

public class Tooltip : MonoBehaviour
{

    private Player player;
    public GameObject startPoint;
    public GameObject line;
    public GameObject textCanvas;

    //GameObject sphere1, sphere2;
    Vector3 endPoint;
    Vector3 offset = new Vector3(.0f, -.25f, .3f);

    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
        AlertsHandler.OnScanPlateResult += ShowTooltip;
        AlertsHandler.OnScanDriverLicenseResult += ShowTooltip;
        for (int i = 0; i < gameObject.transform.childCount; i++)
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        //sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere1.transform.localScale = new Vector3(.3f, .3f, .3f);
        //sphere2.transform.localScale = new Vector3(.3f, .3f, .3f);
    }

    private void ShowTooltip(int _scanCode)
    {
        
        textCanvas.transform.GetChild(0).GetComponentInChildren<Image>().color = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);

        if (!IsArmDisplayOnSight())
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }


    }

    bool IsArmDisplayOnSight()
    {
        if (Vector3.Angle(player.hmdTransform.position + player.hmdTransform.forward, transform.parent.transform.position - transform.parent.transform.up) < 3.0f)
            return true;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        //sphere1.transform.position = player.hmdTransform.position + player.hmdTransform.forward;
        //sphere2.transform.position = transform.parent.transform.position - transform.parent.transform.up;

//        Debug.Log(Vector3.Angle(player.hmdTransform.position + player.hmdTransform.forward, transform.parent.transform.position - transform.parent.transform.up));
        if (IsArmDisplayOnSight())
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }


        Transform playerTransform = player.hmdTransform;
        endPoint = playerTransform.position + offset;

        textCanvas.transform.position = endPoint;
        textCanvas.transform.rotation = Quaternion.identity;

        Vector3 vDir = playerTransform.position - endPoint;

        Quaternion standardLookat = Quaternion.LookRotation(vDir, Vector3.up);
        Quaternion upsideDownLookat = Quaternion.LookRotation(vDir, playerTransform.up);

        float flInterp;
        if (playerTransform.forward.y > 0.0f)
        {
            flInterp = Util.RemapNumberClamped(playerTransform.forward.y, 0.6f, 0.4f, 1.0f, 0.0f);
        }
        else
        {
            flInterp = Util.RemapNumberClamped(playerTransform.forward.y, -0.8f, -0.6f, 1.0f, 0.0f);
        }

        textCanvas.transform.rotation = Quaternion.Slerp(standardLookat, upsideDownLookat, flInterp);

        Transform lineTransform = line.transform;
        LineRenderer lineR =  line.GetComponent<LineRenderer>();
        lineR.useWorldSpace = false;
        lineR.SetPosition(0, lineTransform.InverseTransformPoint(startPoint.transform.position));
        lineR.SetPosition(1, lineTransform.InverseTransformPoint(endPoint));
    }

}
