using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Brush-type fade off the fog by ray.
public class FogRay : FogListener
{
    [SerializeField]
    private FirefighterListener FirefighterListener;
    private Color[] Colors;
    public float Radius = 5f; //Size of the brush.
    private float RadiusSqr { get { return Radius * Radius; } }

    private void Start()
    {
        SetupFog();
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
            if (Physics.Raycast(ri, out hit, 1000, FogLayer, QueryTriggerInteraction.Collide))
            {
                for (int i = 0; i < Vertices.Length; i++)
                {
                    Vector3 v = FogPlane.transform.TransformPoint(Vertices[i]);
                    float dist = Vector3.SqrMagnitude(v - hit.point);
                    if (dist < RadiusSqr)
                    {
                        float alpha = Mathf.Min(Colors[i].a, dist / RadiusSqr);
                        Colors[i].a = alpha;
                    }
                }
                UpdateColor();
            }
        }
    }


    protected override void SetupFog()
    {
        base.SetupFog();
        FogMesh = FogPlane.GetComponent<MeshFilter>().mesh;
        Vertices = FogMesh.vertices;
        Colors = new Color[Vertices.Length];
        for (int i = 0; i < Colors.Length; i++)
        {
            Colors[i] = Color.black;
        }
        UpdateColor();
    }

    private void UpdateColor()
    {
        FogMesh.colors = Colors;
    }
}
