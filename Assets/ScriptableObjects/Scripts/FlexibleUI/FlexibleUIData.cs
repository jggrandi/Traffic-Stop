using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New FlexibleUIData", menuName = "Traffic-Stop/FlexibleUI/FlexibleUIData")]
public class FlexibleUIData : ScriptableObject
{
    [Header("Button Sprite")]
    public Sprite buttonSprite;
   
    [Header("Colors")]
    public ColorVariable defautColor;
    public ColorVariable lowPriorityColor;
    public ColorVariable mediumPriorityColor;
    public ColorVariable highPriorityColor;

    public ColorVariable hoverButtonColor;
    public ColorVariable selectedButtonColor;

    [Header("Text")]
    public TMP_FontAsset fontType;
    public Color fontColor;
}
