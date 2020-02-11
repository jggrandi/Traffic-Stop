using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using System;

public class Driver_IK : EventsIK
{
    public FullBodyBipedIK ik;
    public Transform leftHandTarget, leftFootTarget, rightFootTarget;
    private IKSolverLookAt headIKTarget;

    public Transform[] rightHandTarget;
    public HandPoser handPoser;


    private void Start()
    {
        LookAtIK lookAt = gameObject.GetComponent(typeof(LookAtIK)) as LookAtIK;
        headIKTarget = lookAt.solver;
    }

    private void LateUpdate()
    {

        if (!headIK)
        {
            if(headWeight >0)
            {
                headWeight -= 2f * Time.deltaTime;
            }
            headIKTarget.SetLookAtWeight(headWeight);
        }
        else
        {
            if(headWeight < 1)
            {
                headWeight += 2f * Time.deltaTime;
            }
            headIKTarget.SetLookAtWeight(headWeight);
        }

        if (rightHandLock)// if it is locked to the steering wheel
        {
            if(weight < 1f)
            {
                weight += 2f * Time.deltaTime; 
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
