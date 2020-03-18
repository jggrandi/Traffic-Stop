using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class FlexibleUIButton : FlexibleUI
{
    public enum ButtonType { Default, LowPriority, MediumPriority, HighPriority} 

    Image image;
    Button button;
    TextMeshProUGUI text;
    public ButtonType buttonType;
    public string displayText;


    protected override void OnSkinUI()
    {
        base.OnSkinUI();
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();

        button.transition = Selectable.Transition.ColorTint;
        button.targetGraphic = image;

        image.sprite = skinData.buttonSprite;
        image.type = Image.Type.Sliced;
        //button.spriteState = skinData.buttonSpriteState;
        text.text = displayText;
        text.font = skinData.fontType;
        text.color = skinData.fontColor;


        switch (buttonType)
        {
            case ButtonType.LowPriority:
                image.color = skinData.lowPriorityColor.color;
                break;
            case ButtonType.MediumPriority:
                image.color = skinData.mediumPriorityColor.color;
                break;
            case ButtonType.HighPriority:
                image.color = skinData.highPriorityColor.color;
                break;
            case ButtonType.Default:
                image.color = skinData.defautColor.color;
                break;

        }
    }

}
