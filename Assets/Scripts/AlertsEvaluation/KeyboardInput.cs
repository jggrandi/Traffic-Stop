using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour, IInputProvider
{
    public bool IsMainKeyPressed { get; set; }
    public int OptionSelected { get; set; }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            IsMainKeyPressed = true;
        else if (Input.GetKeyUp(KeyCode.Space))
            IsMainKeyPressed = false;
        else if (Input.GetKey(KeyCode.Space))
            IsMainKeyPressed = true;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            OptionSelected = 0; // Low
         if (Input.GetKeyDown(KeyCode.RightArrow))
            OptionSelected = 1; // Med
         if (Input.GetKeyDown(KeyCode.DownArrow))
            OptionSelected = 2; // High

    }
}
