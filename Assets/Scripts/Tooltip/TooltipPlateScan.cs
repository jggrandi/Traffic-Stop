using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TooltipPlateScan : Tooltip
{

    // Start is called before the first frame update
    void Start()
    {
        //player = Player.instance;

        InitalSetup();
        SetTooltipText("Start by scanning the vehicle's plate");

        AlertsHandler.OnScanPlate += SetHideTooltip;
        AlertsHandler.OnScanPlateResult += NextPhase;
        //AlertsHandler.OnScanDriverLicenseResult += ShowTooltip;

        //line = this.transform.GetChild(0).gameObject;
        //textCanvas = this.transform.GetChild(1).gameObject;

        //for (int i = 0; i < gameObject.transform.childCount; i++)
        //    gameObject.transform.GetChild(i).gameObject.SetActive(false);
        //sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere1.transform.localScale = new Vector3(.3f, .3f, .3f);
        //sphere2.transform.localScale = new Vector3(.3f, .3f, .3f);
    }

    public void NextPhase(int i)
    {
        UIGuider.Instance.NextPhase();
    }

    public void SetHideTooltip(int i)
    {
        HideTooltip();
    }

    protected override void ShowTooltip(int _scanCode)
    {
        //textCanvas.transform.GetChild(0).GetComponentInChildren<Image>().color = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
        if (!IsArmDisplayOnSight())
            base.ShowTooltip(_scanCode);
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
        //if (IsArmDisplayOnSight())
        //    HideTooltip();


        MakeTheMagicHappen();

    }

}

