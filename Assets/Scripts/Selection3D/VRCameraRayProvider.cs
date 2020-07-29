using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
// Provides a ray that is starts from the center of the HMD along the forward direction.

public class VRCameraRayProvider : MonoBehaviour, IRayProvider
{    
    public Ray CreateRay()
    {

        return new Ray(Player.instance.hmdTransform.position, Player.instance.hmdTransform.forward);        
    }
}
