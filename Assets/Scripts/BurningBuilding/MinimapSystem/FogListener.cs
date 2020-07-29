//=============================================================================
//
// Purpose: Handle the fog layer of the minimap.
//
//=============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using Valve.Newtonsoft.Json.Bson;

public class FogListener : MonoBehaviour
{
    [SerializeField]
    protected GameObject MinimapCamera;
    protected Mesh FogMesh;
    protected GameObject FogPlane { get { return this.gameObject; } }




    [SerializeField]
    protected LayerMask FogLayer;
    protected Vector3[] Vertices; // Vertices of FigPlane, for future partial fadeoff purpose.

    protected virtual void InitalSetup()
    {
        BurningBuildingHandler.UpdateContent += Content;
    }
    protected virtual void Content(GameObject _candidate)
    {
    }

    protected virtual void SetupFog()
    {
        Assert.IsNotNull(FogPlane);
        InitalSetup();
        if (FogPlane.layer != 12)
        {
            FogPlane.layer = 12;
            foreach (Transform child in FogPlane.transform)
            {
                child.gameObject.layer = 12;
            }
        }
    }

}
