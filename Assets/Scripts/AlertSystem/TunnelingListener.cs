using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sigtrap.VrTunnellingPro;
using Valve.VR.InteractionSystem;

// Activates the tunneling alert 

public class TunnelingListener : MonoBehaviour
{
    private IEnumerator coroutine;
    Tunnelling tunnelling;
    private bool callAlert = true;

    void Start()
    {
        LicenseScanListener.OnReady += ShowTunnel;
        PlateScanListener.OnReady += ShowTunnel;
        ButtonBehavior.OnClicked += ResetTunnel;
        FirefighterListener.ShowUI += ShowFlashingTunnel;

        //AlertsHandler.TriggerResultOfLicenseScan += ShowTunnel;
        //AlertsHandler.OnScanDriverLicenseResult += ShowTunnel;
        tunnelling = gameObject.GetComponent<Tunnelling>();
    }

    void ShowTunnel(GameObject _obj)
    {
        AlertObject aObj = _obj.GetComponent<AlertObject>();
        if (aObj.LevelAlert == AlertObject.AlertLevel.high)
        {
            tunnelling.effectColor = Utils.DefineColorBasedOnAlertCode(aObj.LevelAlert);
            tunnelling.effectCoverage = .7f;
            tunnelling.effectFeather = .15f;

            coroutine = WaitScan(5f);
            StartCoroutine(coroutine);
        }
    }

    //void ShowTunnel( int _scanCode)
    //{
    //    if (_scanCode == (int)AlertsHandler.ScanCode.Warning)
    //    {
    //        tunnelling.effectColor = AlertsHandler.DefineColorBasedOnAlertCode(_scanCode);
    //        tunnelling.effectCoverage = .7f;
    //        tunnelling.effectFeather = .15f;

    //        coroutine = WaitScan(5f);
    //        StartCoroutine(coroutine);
    //    }
    //}

    void ResetTunnel()
    {
        tunnelling.effectCoverage = 0f;
        tunnelling.effectFeather = 0f;
    }

    private IEnumerator WaitScan(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ResetTunnel();
    }


    private void OnDisable()
    {
        //AlertsHandler.OnScanDriverLicenseResult -= ShowTunnel;
        LicenseScanListener.OnReady -= ShowTunnel;
    }

    void ShowFlashingTunnel(GameObject _obj)
    {
        coroutine = WaitAlert(4f);
        FireFighter player = Camera.main.transform.parent.parent.GetComponentInChildren<StoreFirefighterData>().data; ;
        //te'cDebug.Log(callAlert);
        if (player.isPlayer && player.alertLevel != AlertObject.AlertLevel.none && callAlert)
        {
            tunnelling.effectColor = Utils.DefineColorBasedOnAlertCode(player.alertLevel);
            tunnelling.effectCoverage = .7f;
            tunnelling.effectFeather = .15f;
            StartCoroutine(coroutine);
        }
        else if (player.isPlayer && player.alertLevel == AlertObject.AlertLevel.none)
        {
            StopCoroutine(coroutine);
            ResetTunnel();
            callAlert = true;
        }
    }


    private IEnumerator WaitAlert(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        callAlert = false;
        ResetTunnel();
    }
}
