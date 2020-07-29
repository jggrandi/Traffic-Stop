using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GazeListener : MonoBehaviour
{
    protected Vector3 gazePosition;

    protected virtual void InitalSetup()
    {
        BurningBuildingHandler.UpdateContent += GazeContent;
    }
    private void OnDisable()
    {
        BurningBuildingHandler.UpdateContent -= GazeContent;
    }

    protected virtual void GazeContent(GameObject _candidate)
    {

    }
    
    public virtual Vector3 gazePos()
    {
        return gazePosition;
    }

}
