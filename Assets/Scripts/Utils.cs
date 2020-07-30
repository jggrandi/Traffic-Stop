using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Utils
{
    public static float alpha;
    private static int i = 1;
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

    public static Color DefineFlashingColorBasedOnAlertCode(AlertObject.AlertLevel __code, Color color)
    {
        return DefineFlashingColorBasedOnAlertCode(__code, color.a, new Color(0, 0, 0, 0), ref i);
    }

    public static Color DefineFlashingColorBasedOnAlertCode(AlertObject.AlertLevel __code, float updateAlpha, Color orginColor, ref int alertSpeed)
    {
        Color returnColor;
        switch (__code)
        {
            case AlertObject.AlertLevel.low://Green
                returnColor = new Color(0, 1, 0, updateColorAlpha(ref alertSpeed, updateAlpha, 1));
                break;
            case AlertObject.AlertLevel.medium://Yellow
                returnColor = new Color(1, 0.92f, 0.016f, updateColorAlpha(ref alertSpeed, updateAlpha, 2));
                break;
            case AlertObject.AlertLevel.high://Red
                returnColor = new Color(1, 0, 0, updateColorAlpha(ref alertSpeed, updateAlpha, 4));
                break;
            case AlertObject.AlertLevel.none:
            default:
                returnColor = orginColor;
                break;
        }
        return returnColor;
    }

    private static float updateColorAlpha(ref int speed, float alpha, int amplifier)
    {
        float returnAlpha = alpha;
        if (alpha <= 0)
        {
            returnAlpha = 0;
            speed = Mathf.Abs(speed);
        }
        else if (alpha >= 1)
        {
            returnAlpha = 1;
            speed = -Mathf.Abs(speed);
        }
        returnAlpha += speed * amplifier * Time.deltaTime;
        return returnAlpha;

    }

    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }

    public enum ButtonStatus { none, presed, held, released };
}
