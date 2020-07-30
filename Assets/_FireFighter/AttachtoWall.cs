using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachtoWall : MonoBehaviour
{
    Vector3 hitNormal;
    LayerMask layerMask;
    private Plane[] planes;
    void Start()
    {

        layerMask = LayerMask.GetMask("Environment");
    }

    private void Update()
    {
        if (inSight())
        {
            Debug.Log(this.name);
        }
    }

    public void Transform()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit,
            Mathf.Infinity, layerMask))
        {
            // move the note to the intersection of ray and plane
            transform.position = hit.point;
            // get the normal of the plane pointing away from the note (in the same direction of the normal of the note)
            hitNormal = -hit.normal;
            if (hit.normal.z > 0)
            {
                transform.rotation = Quaternion.FromToRotation(Vector3.forward, absVec3(hitNormal));
                transform.Rotate(0,180f,0,Space.Self);
            }
            else
            {
                transform.rotation = Quaternion.FromToRotation(Vector3.forward, hitNormal);
            }
            transform.Translate(-Vector3.forward * 0.0001f);
            Debug.Log(hit.normal);
        }
    }
    
    private bool inSight()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        Bounds bound = this.GetComponent<Collider>().bounds;
        return GeometryUtility.TestPlanesAABB(planes, this.GetComponent<Collider>().bounds);
    }

    private Vector3 absVec3(Vector3 a)
    {
        return new Vector3(Mathf.Abs(a.x), Mathf.Abs(a.y), Mathf.Abs(a.z));
    }

    public void test()
    {
        Debug.Log(")))))))))))))))0");
    }
}
