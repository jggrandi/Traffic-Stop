using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TooltipArmDisplay : Tooltip
{

    //private Player player;
    //public GameObject startPoint;
    //private GameObject line;
    //private GameObject textCanvas;

    //GameObject sphere1, sphere2;
    //Vector3 endPoint;
    //Vector3 offset = new Vector3(.0f, -.25f, .3f);

    float ANGLE = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //player = Player.instance;

        InitalSetup();
        SetTooltipText("Info Ready");
        //AlertsHandler.OnScanDriverLicenseResult += NextPhase;

        //line = this.transform.GetChild(0).gameObject;
        //textCanvas = this.transform.GetChild(1).gameObject;

        //for (int i = 0; i < gameObject.transform.childCount; i++)
        //    gameObject.transform.GetChild(i).gameObject.SetActive(false);
        //sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere1.transform.localScale = new Vector3(.3f, .3f, .3f);
        //sphere2.transform.localScale = new Vector3(.3f, .3f, .3f);
    }



    protected override void ShowTooltip(int _scanCode)
    {
        //textCanvas.transform.GetChild(0).GetComponentInChildren<Image>().color = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
        if (!IsArmDisplayOnSight())
            base.ShowTooltip(_scanCode);
    }

    bool IsArmDisplayOnSight()
    {
        if (Vector3.Angle(player.hmdTransform.position + player.hmdTransform.forward, startPoint.transform.parent.transform.position - startPoint.transform.parent.transform.up) < ANGLE)
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
            HideTooltip();
            UIGuider.Instance.NextPhase();
        }


        MakeTheMagicHappen();

    }

}
