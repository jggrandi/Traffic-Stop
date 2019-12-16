using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sigtrap.VrTunnellingPro;


public class TunnelingListener : MonoBehaviour
{

    private IEnumerator coroutine;
    Tunnelling tunnelling;
    // Start is called before the first frame update
    void Start()
    {
        //AlertsHandler.TriggerResultOfLicenseScan += ShowTunnel;
        AlertsHandler.OnScanDriverLicenseResult += ShowTunnel;
        tunnelling = gameObject.GetComponent<Tunnelling>();
    }

    void ShowTunnel(int _scanCode)
    {
        tunnelling.effectColor = Color.red;
        tunnelling.effectCoverage = .5f;
        tunnelling.effectFeather = .15f;

        coroutine = WaitScan(3f);
        StartCoroutine(coroutine);
    }

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

}
