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

    void setrightHandLock()
    {
        rightHandLock = true;
    }

    void resetrightHandLock()
    {
        rightHandLock = false;
    }

    void setGetLicense()
    {
        getLicense = true;
    }

    void resetGetLicense()
    {
        LicenseAnim.SetBool(Animator.StringToHash("Play"), false);
        LicenseAnim.SetBool(Animator.StringToHash("Reset"), true);
        getLicense = false;
    }

    private void LateUpdate()
    {
        if (rightHandLock)
        {
            weight = 1f;
            ik.solver.rightHandEffector.position = rightHandTarget[0].position;
            ik.solver.rightHandEffector.rotation = rightHandTarget[0].rotation;
            ik.solver.rightHandEffector.positionWeight = weight;
            ik.solver.rightHandEffector.rotationWeight = weight;
            handPoser.poseRoot = rightHandTarget[0];
        }
        else if (getLicense)
        {
            weight = 1f;
            ik.solver.rightHandEffector.position = rightHandTarget[1].position;
            ik.solver.rightHandEffector.rotation = rightHandTarget[1].rotation;
            ik.solver.rightHandEffector.positionWeight = weight;
            ik.solver.rightHandEffector.rotationWeight = weight;
            handPoser.poseRoot = rightHandTarget[1];
            LicenseAnim.SetBool(Animator.StringToHash("Play"), true);
            LicenseAnim.SetBool(Animator.StringToHash("Reset"), false);
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
