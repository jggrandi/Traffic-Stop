using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class AssignTrackedDevice : MonoBehaviour
{
    ETrackedDeviceClass trackedClass;
    SteamVR_TrackedObject trackedObj;
    // Start is called before the first frame update
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        for (uint i = 0; i < 16; i++)
        {
            if (OpenVR.System.GetTrackedDeviceClass(i) == ETrackedDeviceClass.GenericTracker)
            {
                trackedObj.index = (SteamVR_TrackedObject.EIndex)i;
                break;
            }

        }

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
