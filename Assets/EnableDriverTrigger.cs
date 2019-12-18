using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDriverTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Valve.VR.InteractionSystem.Sample.InteractableExample.OnHoldLicense += EnableTrigger;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnableTrigger()
    {
        GetComponent<BoxCollider>().enabled = true;
    }

}
