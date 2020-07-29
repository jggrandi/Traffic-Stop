using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using Valve.Newtonsoft.Json.Bson;

public class MinimapListener : MonoBehaviour
{
    protected Color[] Colors;
    protected int CurrentFloor { get { return (LayerMask.NameToLayer(CurrentFloorlayer.ToString()) - LayerMask.NameToLayer(Floorlayers.Floor1.ToString())); } }
    public enum Floorlayers
    {
        Floor1,
        Floor2
    };
    protected Floorlayers CurrentFloorlayer;
    protected virtual void UpdateColor() 
    {
    }

    protected virtual void InitalSetup()
    {
        BurningBuildingHandler.UpdateContent += Content;
    }


    protected virtual void Content(GameObject _candidate)
    {

    }

    private void Update()
    {

    }

    private void OnDisable()
    {
        BurningBuildingHandler.UpdateContent -= Content;
    }
}