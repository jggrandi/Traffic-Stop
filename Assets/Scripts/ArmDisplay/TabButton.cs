using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

// Adds the behaviour to the buttons on the arm display.

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Interactable))]
public class TabButton : UIElement
{
    public TabGroup tabGroup;

    public Image background;

    //public UnityEvent onTabSelected;
    //public UnityEvent onTabDeselected;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }


    protected override void OnHandHoverBegin(Hand hand)
    {
        currentHand = hand;
        InputModule.instance.Submit(gameObject);
        tabGroup.OnTabEnter(this);
    }

    protected override void OnHandHoverEnd(Hand hand)
    {
        tabGroup.OnTabExit(this);
        base.OnHandHoverEnd(hand);
    }

    protected override void HandHoverUpdate(Hand hand)
    {
    }

    protected override void OnButtonClick()
    {
        tabGroup.OnTabSelected(this);
    }


    //public void Select()
    //{
    //    if(onTabSelected != null)
    //    {
    //        onTabSelected.Invoke();
    //    }
    //}

    //public void Deselect()
    //{
    //    if(onTabDeselected != null)
    //    {
    //        onTabDeselected.Invoke();
    //    }
    //}

}
