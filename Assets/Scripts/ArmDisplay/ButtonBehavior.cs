using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public static Action OnClicked;

    protected Button b;

    bool isEnabled = false;
    bool isClicked = false;

    public bool IsEnabled { get => isEnabled; set => isEnabled = value; }
    public bool IsClicked { get => isClicked; set => isClicked = value; }

    protected virtual void Enable(GameObject _obj)
    {
        Utils.ChangeButtonColor(Utils.DefineColorBasedOnAlertCode(_obj.GetComponent<AlertObject>().LevelAlert), b);
        b.interactable = true;
        b.GetComponentInChildren<BoxCollider>().enabled = true;
        IsEnabled = true;
    }

    protected virtual void Disable()
    {
        Utils.ChangeButtonColor(new Color32(225, 225, 225, 0), b);
        b.interactable = false;
        b.GetComponentInChildren<BoxCollider>().enabled = false;
        IsEnabled = false;
        IsClicked = false;
    }

    protected virtual void ChangeState()
    {
        FadeButtonColor();
    }

    private void FadeButtonColor()
    {
        Color color = Utils.GetButtonColor(b);
        Color newColor = new Color(color.r, color.g, color.b, 0.2f);
        Utils.ChangeButtonColor(newColor, b);

    }

    public void Clicked()
    {
        if (isClicked) return;
        
        isClicked = true;
        ChangeState();
        OnClicked();    
    }

}
