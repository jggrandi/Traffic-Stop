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
public class GrabDriversLicense : UIScanListner
{
    public GameObject targetReference;

    private Vector3 oldPosition;
    private Quaternion oldRotation;

    private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);

    private Interactable interactable;

    public static Action OnHoldLicense;
    public static Action OnReturnLicense;
    public static Action OnPutLicenseBack;

    private bool isGrabEnding;
    public static bool isGrabbing = false;


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
        InitalSetup();
        AlertsHandler.OnScanDriverLicenseResult += AllowDriversLicenseReturn;
        AlertsHandler.OnScanDriverLicense += ShowScanning;
        AlertsHandler.OnScanDriverLicenseResult += ShowResultOfScan;
        HandleInteractableArea.OnExitInteractableArea += ResetLicenseAlert;
    }

    private void ResetLicenseAlert()
    {
        InitalSetup();
        isLicenseScanned = false;

    }

    private void OnDisable()
    {
        AlertsHandler.OnScanDriverLicenseResult -= AllowDriversLicenseReturn;
        AlertsHandler.OnScanDriverLicense -= ShowScanning;
        AlertsHandler.OnScanDriverLicenseResult -= ShowResultOfScan;
        HandleInteractableArea.OnExitInteractableArea -= ResetLicenseAlert;
    }

    protected override void ShowScanning(int _scanCode)
    {
        if (!isGrabbing) return;
        base.ShowScanning(_scanCode);
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
            isGrabbing = true;
            OnHoldLicense();
            // Save our position/rotation so that we can restore it when we detach
            oldPosition = transform.position;
            oldRotation = transform.rotation;

            // Call this to continue receiving HandHoverUpdate messages,
            // and prevent the hand from hovering over anything else
            hand.HoverLock(interactable);
            //isGrabing = true;
            // Attach this object to the hand
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
        }
        else if (isGrabEnding)
        {
            isGrabbing = false;
            OnPutLicenseBack();
            HideBrackets();
            //isGrabing = false;
            // Detach this object from the hand
            hand.DetachObject(gameObject);

            // Call this to undo HoverLock
            hand.HoverUnlock(interactable);

            // Restore position/rotation
            transform.position = oldPosition;
            transform.rotation = oldRotation;

            //transform.position = Vector3.Lerp(transform.position, oldPosition, 0.01f);
            //transform.rotation = Quaternion.Slerp(transform.rotation, oldRotation, 0.3f);
        }
    }

    private void FixedUpdate()
    {
        //Debug.Log(Vector3.Distance(transform.position, reference.transform.position));

        if (!isGrabbing) return;
        if (!isLicenseScanned) return;
        if (IsAbleToReturnDriversLicense())
            OnReturnLicense();
    }

    bool IsAbleToReturnDriversLicense()
    {
        if( Vector3.Distance(transform.position, targetReference.transform.position) <= 0.1f)
            return true;
        return false;
    }

    void AllowDriversLicenseReturn(int _code)
    {
        isLicenseScanned = true;
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
        Debug.Log("awwwee");
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
