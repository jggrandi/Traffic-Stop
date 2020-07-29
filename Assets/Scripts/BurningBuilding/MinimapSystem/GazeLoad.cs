using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GazeLoad : GazeListener
{

    [SerializeField]
    private GameObject Minimap;

    private Timer timer;
    private MinimapLoad mapLoad;

    [SerializeField]
    private GameObject Aim;


    private bool isReady = false; //minimap whether ready to be on/off. 
    protected override void InitalSetup()
    {
        base.InitalSetup();
        mapLoad = Minimap.GetComponent<MinimapLoad>();
        timer = GetComponentInChildren<Timer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitalSetup();
    }


    protected override void GazeContent(GameObject _candidate)
    {
        GazetoWorldPosition();
        bool h = hitTrigger();
        loadMap(h);
    }

    //Gaze to world position
    private void GazetoWorldPosition()
    {
        Vector3 crusorPos = Input.mousePosition;
        crusorPos.z = 0.5f;
        crusorPos.y += 500f;
        crusorPos.x += 300f;
        gazePosition = Camera.main.ScreenToWorldPoint(crusorPos);
    }
    
    // Detect whether gaze hits the minimap trigger.
    private bool hitTrigger()
    {
        Vector3 direction = -Player.instance.hmdTransform.position + gazePosition;
        direction /= direction.magnitude;
        RaycastHit hit;
        if (Physics.Raycast(Player.instance.hmdTransform.position, direction, out hit, 1000f))
        {
            return hit.collider.gameObject.CompareTag("Trigger");
        }
        return false;
    }

    // Update Reticle's position to current gaze's position
    private void updatePos()
    {
        transform.position = gazePosition;
    }

    // Loadind map.
    private void loadMap(bool gazeHit)
    {
        updatePos();

        if (mapLoad.loaded)// If minimap is loaded
        {
            if (!gazeHit) // Gaze is off trigger, reset all parameters and minimap is ready to turn off.
            {
                Aim.SetActive(false);
                timer.Reset();
                isReady = true;
            }
            else if(gazeHit && isReady)// Gaze hits the trigger and minimap is ready to turn off.
            {
                reverseLoadingReticle();
                if (timer.TimeIsUp)//wait till reticle finishes loading
                {
                    mapLoad.isLoad = false;
                    mapLoad.isDeload = true;
                    isReady = false;
                }
            }
        }
        else // Minimap is not loaded
        {
            if(gazeHit && isReady)
            {
                loadingReticle();
                if (timer.TimeIsUp)
                {
                    mapLoad.isLoad = true;
                    mapLoad.isDeload = false;
                    isReady = false;
                }
            }
            else if(!gazeHit)
            {
                Aim.SetActive(false);
                timer.Reset();
                isReady = true;
            }
        }
    }

    private void loadingReticle()
    {
        Aim.SetActive(true);
        timer.RunTimer = true;
        GetComponentInChildren<ProgressUpdater>().reverseUpdate = false;
    }
 
    private void reverseLoadingReticle()
    {
        Aim.SetActive(true);
        timer.RunTimer = true;
        GetComponentInChildren<ProgressUpdater>().reverseUpdate = true;
    }

    public override Vector3 gazePos()
    {
        return new Vector3 (gazePosition.x, gazePosition.y,gazePosition.z);
    }
}
