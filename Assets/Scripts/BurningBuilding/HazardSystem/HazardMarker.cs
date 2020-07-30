using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Boo.Lang.Runtime.DynamicDispatching;
using UnityEngine.UI;

public class HazardMarker : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = Camera.main.transform.position;
        canvas.transform.LookAt(new Vector3(camPos.x, 0, camPos.z));
    }

    public void active()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (child != null)
            {
                child.SetActive(true);
            }
        }
    }

    public void setRoomNumber(int number)
    {
        canvas.GetComponentInChildren<TextMeshProUGUI>().text = number.ToString();
    }

    public void setHazardImage(Sprite image)
    {
        Image[] images = GetComponentsInChildren<Image>();
        foreach(Image i in images)
        {
            i.sprite = image;
        }
    }
}


