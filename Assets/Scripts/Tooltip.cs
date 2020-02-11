using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{

    private Player player;
    public GameObject startPoint;
    public GameObject endPoint;
    public GameObject line;
    public GameObject textCanvas;

    

    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = player.hmdTransform;
        endPoint.transform.position = playerTransform.position + new Vector3(0f,0f,.3f);

        textCanvas.transform.position = endPoint.transform.position;
        textCanvas.transform.rotation = Quaternion.identity;

        Vector3 vDir = playerTransform.position - endPoint.transform.position;

        Quaternion standardLookat = Quaternion.LookRotation(vDir, Vector3.up);
        Quaternion upsideDownLookat = Quaternion.LookRotation(vDir, playerTransform.up);

        float flInterp;
        if (playerTransform.forward.y > 0.0f)
        {
            flInterp = Util.RemapNumberClamped(playerTransform.forward.y, 0.6f, 0.4f, 1.0f, 0.0f);
        }
        else
        {
            flInterp = Util.RemapNumberClamped(playerTransform.forward.y, -0.8f, -0.6f, 1.0f, 0.0f);
        }

        textCanvas.transform.rotation = Quaternion.Slerp(standardLookat, upsideDownLookat, flInterp);

        Transform lineTransform = line.transform;
        LineRenderer lineR =  line.GetComponent<LineRenderer>();
        lineR.useWorldSpace = false;
        lineR.SetPosition(0, lineTransform.InverseTransformPoint(startPoint.transform.position));
        lineR.SetPosition(1, lineTransform.InverseTransformPoint(endPoint.transform.position));
    }

    void CreateHint()
    {


    }
}
