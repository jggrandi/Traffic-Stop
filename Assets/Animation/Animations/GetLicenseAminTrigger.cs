using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLicenseAminTrigger : MonoBehaviour
{
    public Driver_IK driver;
    private Animator driverAmin;

    private void Start()
    {
        driverAmin = GameObject.Find("MaleD").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " " + Time.time);
        if (other.name == "finger_middle_1_r" && !driverAmin.GetBool("GetLicense") && driverAmin.GetBool("LicensePassReset"))
        {
            driverAmin.SetBool("GetLicense", true);
            driverAmin.SetBool("LicensePassReset", false);
        }
        if (other.name.Contains("finger") && driverAmin.GetBool("GetLicense") && driver.license.isGrabEnding)
        {
            driverAmin.SetBool("GetLicense", false);
            driverAmin.SetBool("GrabLicense", true);
        }
    }
}
