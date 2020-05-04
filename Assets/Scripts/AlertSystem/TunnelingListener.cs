using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sigtrap.VrTunnellingPro;

// Activates the tunneling alert 

public class TunnelingListener : MonoBehaviour
{
    private IEnumerator coroutine;
    Tunnelling tunnelling;

    void Start()
    {
        LicenseScanListener.OnReady += ShowTunnel;
        PlateScanListener.OnReady += ShowTunnel;
        ButtonBehavior.OnClicked += ResetTunnel;

        //AlertsHandler.TriggerResultOfLicenseScan += ShowTunnel;
        //AlertsHandler.OnScanDriverLicenseResult += ShowTunnel;
        tunnelling = gameObject.GetComponent<Tunnelling>();
    }

    void ShowTunnel(GameObject _obj)
    {
        AlertObject aObj = _obj.GetComponent<AlertObject>();
        if(aObj.LevelAlert == AlertObject.AlertLevel.high)
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
}
