//=============================================================================
//
// Purpose: Render minimap with a render texture caputured by an 
//          orthographic camera.
//
//=============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class MinimapTextureListener : MinimapListener
{
    // Texture for the minimap, which is captured by a camera.
    [SerializeField]
    private RenderTexture PlanTexture;

    [SerializeField]
    private Texture[] FloornumberTexture;
    [SerializeField]
    private GameObject MinimapPlane;
    [SerializeField]
    private GameObject FloorPlane;

    [SerializeField]
    private GazeLoad gazeLoad;

    private bool minimapLoaded;
    private Vector3 gazePosition;
    protected override void InitalSetup()
    {
        base.InitalSetup();
        AssignMinimapTexture();
    }

    private void Start()
    {
        InitalSetup();
    }


    private void AssignMinimapTexture()
    {
        RawImage renderer_Minimap = MinimapPlane.GetComponent<RawImage>();
        //renderer_Minimap.texture = PlanTexture;
        //Renderer renderer_Minimap = MinimapPlane.GetComponent<Renderer>();
        renderer_Minimap.material.SetTexture("_DetailTex", PlanTexture);
    }

    protected override void Content(GameObject _candidate)
    {
        ChangeFloor();
        //GazeDetect();
        ChangeAlpha();
    }

    // Detect the current floor player is, change the culling mask of minimap camera and fllor 
    // number at minimap correpondingly.
    private void ChangeFloor()
    {
        RawImage renderer_Floor = FloorPlane.GetComponent<RawImage>();
        renderer_Floor.texture = FloornumberTexture[CurrentFloor];
    }

    
    private float Distance()
    {
        gazePosition = gazeLoad.gazePos();
        return Vector3.Distance(MinimapPlane.transform.position, gazePosition);
    }

    private void ChangeAlpha()
    {
        minimapLoaded = MinimapPlane.GetComponentInParent<MinimapLoad>().loaded;
        Color c1= MinimapPlane.GetComponent<RawImage>().color;
        Color c2 = FloorPlane.GetComponent<RawImage>().color;
        Color c3 = MinimapPlane.transform.parent.GetComponent<Image>().color;
        if (minimapLoaded)
        {
            float alpha = Distance() <= 0.4f? 1 : Mathf.Max(0, 1 - Mathf.Abs(Distance() - 0.4f) / 0.6f);
            c1.a = c2.a = c3.a = alpha;
        }
        else
        {
            c1.a = c2.a = c3.a = 1f;
        }
        MinimapPlane.GetComponent<RawImage>().color = c1;
        FloorPlane.GetComponent<RawImage>().color = c2;
        MinimapPlane.transform.parent.GetComponent<Image>().color = c3;
    }
}
