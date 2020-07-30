using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class RoomListener : MonoBehaviour
{
    private static int totalRoomEntered = 0;
    public int currentRoomNumber { get; private set; }
    //private GameObject wall;

    [SerializeField]
    private TextMeshProUGUI mapRoomNumber;


    private void Start()
    {
        mapRoomNumber.gameObject.SetActive(false);
        //foreach (Transform child in transform)
        //{
        //    if (child.gameObject.layer == LayerMask.NameToLayer("Wall"))
        //    {
        //        wall = child.gameObject;
        //    }
        //}
    }

    void Update()
    {
        mapRoomNumber.text = currentRoomNumber.ToString();
        mapRoomNumber.color = Color.grey;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Firefighter") )
        {
            if (!mapRoomNumber.transform.gameObject.activeInHierarchy)
            {
                totalRoomEntered += 1;
                currentRoomNumber = totalRoomEntered;
                mapRoomNumber.gameObject.SetActive(true);
            }
            //if (other.gameObject.transform == Player.instance.transform)
            //{
            //    wall.SetActive(true);
            //}
        }
        if (other.gameObject.CompareTag("HazardMarker"))
        {
            other.gameObject.GetComponent<HazardMarker>().setRoomNumber(currentRoomNumber);
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Firefighter") && other.gameObject.transform == Player.instance.transform)
    //    {
    //        wall.SetActive(false);
    //    }
    //}

    public void reset()
    {
        totalRoomEntered = 0;
    }
}
