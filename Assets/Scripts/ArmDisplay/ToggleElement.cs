using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleElement : MonoBehaviour
{
    public GameObject menuElement;
    public GameObject canvasElement;



    public void Toogle()
    {
        menuElement.SetActive(!menuElement.activeInHierarchy);
        canvasElement.GetComponent<CanvasGroup>().alpha = System.Convert.ToInt32(menuElement.activeInHierarchy);
    }
}
