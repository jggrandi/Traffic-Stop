using System.Linq;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Fade off the fog of each room entered by firefighters.
public class FogRoomCross : FogListener
{
    private FirefighterListener FirefighterListener;
    private Transform[] Fogs; //Each room has its own same shape fog plane;
    private void Start()
    {
        SetupFog();
        FirefighterListener = Player.instance.transform.gameObject.GetComponentInChildren<FirefighterListener>();
    }

    protected override void Content(GameObject _candidate)
    {
        Ray[] r = new Ray[FirefighterListener.Firefighters.Length];
        // For each firefighter, create a ray to track.
        for (int i = 0; i < r.Length; i++)
        {
            r[i] = new Ray(MinimapCamera.transform.position, FirefighterListener.Firefighters[i].transform.position - MinimapCamera.transform.position);
        }
        // Fade off the fog at region hit by the ray.
        foreach (Ray ri in r)
        {
            RaycastHit hit;
            if (Physics.Raycast(ri, out hit, Mathf.Infinity, FogLayer, QueryTriggerInteraction.Collide))
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
    }

    protected override void SetupFog()
    {
        base.SetupFog();
        Fogs = FogPlane.GetComponentsInChildren<Transform>();
        Fogs = Fogs.Skip(1).ToArray();
        foreach(Transform f in Fogs)
        {
            f.gameObject.GetComponentInChildren<MeshRenderer>().material = CreateMaterial();
        }
    }

    private Material CreateMaterial()
    {
        Material mat = new Material((Shader.Find("Minimap/Diffuse")));
        mat.SetColor("_Color", Color.black);
        return mat;

    }
}
