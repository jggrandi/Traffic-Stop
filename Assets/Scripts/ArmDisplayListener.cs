using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmDisplayListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ToggleArmUIOnLook.TriggerArmDisplay += ShowArmDisplay;
        ToggleArmUIOnLook.HideArmDisplay += HideDisplay;
    }

    void ShowArmDisplay()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
    }

    void HideDisplay()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
    }

}
