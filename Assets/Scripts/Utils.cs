using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Utils
{

    public static Color DefineColorBasedOnAlertCode(AlertObject.AlertLevel __code)
    {
        Color returnColor;
        switch (__code)
        {
            case AlertObject.AlertLevel.low:
                returnColor = Color.green;
                break;
            case AlertObject.AlertLevel.medium:
                returnColor = Color.yellow;
                break;
            case AlertObject.AlertLevel.high:
                returnColor = Color.red;
                break;
            case AlertObject.AlertLevel.none:
            default:
                returnColor = Color.white;
                break;
        }
        return returnColor;
    }

    public static void ChangeButtonColor(Color _c, Button _b)
    {
        ColorBlock colors = _b.colors;
        colors.normalColor = _c;
        _b.colors = colors;
    }

    public static float Scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }

    public static Color GetButtonColor(Button _b)
    {
        ColorBlock colors = _b.colors;
        return colors.normalColor;
    }


}
