using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandleAnimations : MonoBehaviour
{

    GameObject ASD;
    public List<Animator> animations = new List<Animator>();
    string[] animationNames = { "AudiAnim", "DriverAni","DriverLicense"};
    // Start is called before the first frame update
    void Start()
    {
        foreach (string s in animationNames)
        {
            LoadAnimation("AudiAnim");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadAnimation(string _name)
    {
        RuntimeAnimatorController newController = (RuntimeAnimatorController)Resources.Load("Animations/" + _name, typeof(RuntimeAnimatorController));
        //Animator tempObj = Resources.Load("Animations/" + _name, typeof(Animator)) as Animator;
        if (!newController == null)
        {
            Debug.LogError("Animation NOT found");
        }
        else
        {
            Debug.Log(newController);
            //animations.Add()
            //animation = tempObj.GetComponent<Animation>();
            //animanClip = animation.clip;

            //animation.AddClip(animanClip, _name);
        }
    }


    //void ReturnDriverLicense()
    //{
    //    //onDriverlicenseReturn(); // NECESSARY TO other scripts to be aware that the driver license was returned to the driver
    //    //Selector3D.SetActive(false); //Old stuff that deactivated the UI on the vehicle's plate
    //    amins[0].SetBool(HeadRot, false);
    //    amins[0].SetBool(LicensePass, false);
    //    amins[0].SetBool(LicensePassReset, false);
    //    amins[0].SetBool(Leave, false);
    //    amins[0].SetBool(GetLicense, true);
    //    amins[0].SetBool(GrabLicense, false);
    //}

    //void PutBackLicense()
    //{
    //    //driverLicense.SetActive(true);
    //    amins[0].SetBool(HeadRot, false);
    //    amins[0].SetBool(LicensePass, false);
    //    amins[0].SetBool(LicensePassReset, false);
    //    amins[0].SetBool(Leave, false);
    //    amins[0].SetBool(GetLicense, false);
    //    amins[0].SetBool(GrabLicense, true);
    //    amins[2].SetBool(Reverse, false);
    //    amins[2].SetBool(PlaceLice, true);
    //}


    //void RestoreHandToNormalPose()
    //{
    //    //LipSyncAction(LipAnim[3]);
    //    amins[0].SetBool(HeadRot, false);
    //    amins[0].SetBool(LicensePass, false);
    //    amins[0].SetBool(LicensePassReset, true);
    //    amins[0].SetBool(Leave, false);
    //    amins[2].SetBool(Reverse, false);
    //    amins[2].SetBool(PlaceLice, false);
    //    //driverLicense.SetActive(false);
    //    //Selector3D.SetActive(false);
    //}


    //void DriverLicensePass()
    //{
    //    //Selector3D.SetActive(true);
    //    LipSyncAction(LipAnim[2]);
    //    amins[0].SetBool(HeadRot, false);
    //    amins[0].SetBool(LicensePass, true);
    //    amins[0].SetBool(Leave, false);
    //    amins[0].SetBool(LicensePassReset, false);
    //    amins[0].SetBool(GrabLicense, false);
    //    amins[0].SetBool(GetLicense, false);
    //    coroutine = WaitToShowDriverLicense(5.7f);
    //    StartCoroutine(coroutine);
    //}

    //void FirstHeadRotation()
    //{
    //    ready = true;
    //    amins[0].SetBool(HeadRot, true);
    //    amins[0].SetBool(LicensePassReset, false);
    //    amins[1].SetBool(Open, true);
    //    amins[1].SetBool(Close, false);
    //    amins[0].SetBool(Leave, false);
    //}


    //void ReturnToIdlePosition()
    //{
    //    ready = false;
    //    amins[0].SetBool(HeadRot, false);
    //    amins[0].SetBool(LicensePassReset, false);
    //    amins[0].SetBool(Leave, true);
    //    amins[0].SetBool(LicensePass, false);
    //    amins[1].SetBool(Close, true);
    //    amins[1].SetBool(Open, false);
    //}



}
