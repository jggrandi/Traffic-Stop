using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0F;
    private SteamVR_Action_Vector2 moveAction;
    private void Start()
    {
        moveAction = SteamVR_Input.actionsVector2[0];
    }
    void Update()
    {

        float curSpeed = speed * Time.deltaTime * moveAction.axis.y;
        transform.position = transform.position + Camera.main.transform.forward * curSpeed;
    }
}