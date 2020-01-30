using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;


public class Driver_IK : MonoBehaviour
{
    public FullBodyBipedIK ik;
    public Transform leftHandTarget, leftFootTarget, rightFootTarget;
    public bool rightHandLock = true, getLicense = false;
    public float weight = 1f;
    public Transform[] rightHandTarget;
    public HandPoser handPoser;
    public Animator LicenseAnim;
    public Valve.VR.InteractionSystem.Sample.InteractableExample license;
    private Animator driverAmin;

    private void Start()
    {
        driverAmin = GameObject.Find("MaleD").GetComponent<Animator>();
    }

    void setrightHandLock()
    {
        rightHandLock = true;
        getLicense = false;
    }

    void resetrightHandLock()
    {
        rightHandLock = false;
    }

    void setGetLicense()
    {
        actLicense();
        weight = 1f;
        LicenseAnim.SetBool(Animator.StringToHash("Play"), true);
        LicenseAnim.SetBool(Animator.StringToHash("Reset"), false);
    }

    void actLicense()
    {
        getLicense = true;
    }

    void returnLicense()
    {
        resetrightHandLock();
        actLicense();
        weight = 1f;
        LicenseAnim.SetBool(Animator.StringToHash("Reverse"), true);
        LicenseAnim.SetBool(Animator.StringToHash("PlaceLice"), false);
    }

    void inactLicense()
    {
        getLicense = false;
    }

    void resetGetLicense()
    {
        LicenseAnim.SetBool(Animator.StringToHash("Play"), false);
        //LicenseAnim.SetBool(Animator.StringToHash("Reset"), true);
        inactLicense();
    }




    private void LateUpdate()
    {

        if (rightHandLock)
        {
            if(weight < 1f)
            {
                weight += 2f * Time.deltaTime; ;
            }
            ik.solver.rightHandEffector.position = rightHandTarget[0].position;
            ik.solver.rightHandEffector.rotation = rightHandTarget[0].rotation;
            ik.solver.rightHandEffector.positionWeight = weight;
            ik.solver.rightHandEffector.rotationWeight = weight;
            handPoser.poseRoot = rightHandTarget[0];
        }
        else if (getLicense)
        {
            ik.solver.rightHandEffector.position = rightHandTarget[1].position;
            ik.solver.rightHandEffector.rotation = rightHandTarget[1].rotation;
            ik.solver.rightHandEffector.positionWeight = weight;
            ik.solver.rightHandEffector.rotationWeight = weight;
            handPoser.poseRoot = rightHandTarget[1];

        }
        else
        {
            if (weight > 0f)
            {
                weight -= 2f*Time.deltaTime;
                ik.solver.rightHandEffector.positionWeight = weight;
                ik.solver.rightHandEffector.rotationWeight = weight;
            }
        }
        ik.solver.leftHandEffector.position = leftHandTarget.position;
        ik.solver.leftHandEffector.rotation = leftHandTarget.rotation;
        ik.solver.leftHandEffector.positionWeight = 1f;
        ik.solver.leftHandEffector.rotationWeight = 1f;
        ik.solver.rightFootEffector.position = rightFootTarget.position;
        ik.solver.rightFootEffector.rotation = rightFootTarget.rotation;
        ik.solver.rightFootEffector.positionWeight = 1f;
        ik.solver.rightFootEffector.rotationWeight = 1f;
        ik.solver.leftFootEffector.position = leftFootTarget.position;
        ik.solver.leftFootEffector.rotation = leftFootTarget.rotation;
        ik.solver.leftFootEffector.positionWeight = 1f;
        ik.solver.leftFootEffector.rotationWeight = 1f;
    }
}
