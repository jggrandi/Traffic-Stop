using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ToggleButton : UIElement
{
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void OnHandHoverBegin(Hand hand)
    {
        currentHand = hand;
        InputModule.instance.Submit(gameObject);
    }

    protected override void OnHandHoverEnd(Hand hand)
    {
        base.OnHandHoverEnd(hand);
    }

    protected override void HandHoverUpdate(Hand hand)
    {
    }

    protected override void OnButtonClick()
    {
        Debug.Log("CLICK");
        base.OnButtonClick();
    }
}
