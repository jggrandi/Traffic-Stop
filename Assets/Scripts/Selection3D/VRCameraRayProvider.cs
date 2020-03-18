using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class VRCameraRayProvider : MonoBehaviour, IRayProvider
{    
    public Ray CreateRay()
    {
        return new Ray(Player.instance.hmdTransform.position, Player.instance.hmdTransform.forward);        
    }
}
