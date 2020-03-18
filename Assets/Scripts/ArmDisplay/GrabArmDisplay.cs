//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Demonstrates how to create a simple interactable object
//
//=============================================================================

using UnityEngine;
using System.Collections;
using System;
using Valve.VR.InteractionSystem;

//-------------------------------------------------------------------------
[RequireComponent(typeof(Interactable))]
public class GrabArmDisplay : MonoBehaviour
{
    public GameObject targetReference;
    Transform startPoint;
    private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);

    private Interactable interactable;

    //public static Action OnHoldLicense;
    //public static Action OnReturnLicense;
    //public static Action OnPutLicenseBack;

    private bool isGrabEnding;

    bool isLicenseScanned = false;


    //-------------------------------------------------
    void Awake()
    {
        //var textMeshs = GetComponentsInChildren<TextMesh>();
        //         generalText = textMeshs[0];
        //         hoveringText = textMeshs[1];

        //generalText.text = "No Hand Hovering";
        //hoveringText.text = "Hovering: False";

        interactable = this.GetComponent<Interactable>();
    }

    private void Start()
    {
    }


    //-------------------------------------------------
    // Called when a Hand starts hovering over this object
    //-------------------------------------------------
    private void OnHandHoverBegin(Hand hand)
    {
        //generalText.text = "Hovering hand: " + hand.name;
    }


    //-------------------------------------------------
    // Called when a Hand stops hovering over this object
    //-------------------------------------------------
    private void OnHandHoverEnd(Hand hand)
    {
        //generalText.text = "No Hand Hovering";
    }


    //-------------------------------------------------
    // Called every Update() while a Hand is hovering over this object
    //-------------------------------------------------
    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();
        isGrabEnding = hand.IsGrabEnding(this.gameObject);
        

        if (interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
        {
            // Call this to continue receiving HandHoverUpdate messages,
            // and prevent the hand from hovering over anything else
            hand.HoverLock(interactable);
            //isGrabing = true;
            // Attach this object to the hand
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
        }
        else if (isGrabEnding)
        {
            hand.DetachObject(gameObject);
            
            // Call this to undo HoverLock
            hand.HoverUnlock(interactable);

            startPoint = transform;

            // Restore position/rotation
        }



    }

    //-------------------------------------------------
    // Called when this GameObject becomes attached to the hand
    //-------------------------------------------------
    private void OnAttachedToHand(Hand hand)
    {
        //generalText.text = string.Format("Attached: {0}", hand.name);
        //attachTime = Time.time;
    }



    //-------------------------------------------------
    // Called when this GameObject is detached from the hand
    //-------------------------------------------------
    private void OnDetachedFromHand(Hand hand)
    {
        //Debug.Log("awwwee");
        //generalText.text = string.Format("Detached: {0}", hand.name);
    }


    //-------------------------------------------------
    // Called every Update() while this GameObject is attached to the hand
    //-------------------------------------------------
    private void HandAttachedUpdate(Hand hand)
    {
        //generalText.text = string.Format("Attached: {0} :: Time: {1:F2}", hand.name, (Time.time - attachTime));
    }

    private bool lastHovering = false;

    private void Update()
    {
        if (interactable.isHovering != lastHovering) //save on the .tostrings a bit
        {
            //hoveringText.text = string.Format("Hovering: {0}", interactable.isHovering);
            lastHovering = interactable.isHovering;
        }
        if (startPoint == null) return;
        
        transform.position = Vector3.Lerp(startPoint.position, targetReference.transform.position, 0.1f);
        transform.rotation = Quaternion.Slerp(startPoint.rotation, targetReference.transform.rotation, 0.1f);

        

    }


    //-------------------------------------------------
    // Called when this attached GameObject becomes the primary attached object
    //-------------------------------------------------
    private void OnHandFocusAcquired(Hand hand)
    {
    }


    //-------------------------------------------------
    // Called when another attached GameObject becomes the primary attached object
    //-------------------------------------------------
    private void OnHandFocusLost(Hand hand)
    {
    }



}
