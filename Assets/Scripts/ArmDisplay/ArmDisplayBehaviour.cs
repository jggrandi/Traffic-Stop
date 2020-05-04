using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

// Controls the display of the arm display UI.
// Fades in and out whether the user is looking at it. 

[RequireComponent(typeof(CanvasGroup))]
public class ArmDisplayBehaviour : MonoBehaviour
{
    Player player;
    CanvasGroup canvasGroup;
    GameObject puck;

    float angle;
    static float ANGLE_MAX = 10f;
    
    void Start()
    {
        player = Player.instance;
        puck = this.transform.parent.gameObject;

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            Debug.LogError("Missing component Canvas Group");
        canvasGroup.alpha = 0f;
    }

    private void Update()
    {
        angle = Vector3.Angle(player.hmdTransform.position + player.hmdTransform.forward, transform.parent.transform.position - transform.parent.transform.up);

        canvasGroup.alpha = Utils.Scale(0, ANGLE_MAX, 1, 0, angle);
        
        if(canvasGroup.alpha <= 0.3f) canvasGroup.interactable = false;
        else canvasGroup.interactable = true;
    }

}
