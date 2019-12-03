using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private float rayDistance = 15f;
    public LayerMask layerMask;
    private GameObject currentTarget;

    void Update()
    {
        RaycastHit hit;
        //Debug.DrawRay(transform.position, transform.forward, Color.red, 30f);
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, layerMask))
        {
            if (currentTarget == null)
            {
                currentTarget = hit.transform.gameObject;
                OnRaycasterEnter(currentTarget);
            }
            else if (currentTarget != hit.transform.gameObject)
            {
                OnRaycasterLeave(currentTarget);
                currentTarget = hit.transform.gameObject;
                OnRaycasterEnter(currentTarget);
            }
            OnRaycaster(hit.transform.gameObject);
        }
        else if (currentTarget != null)
        {
            OnRaycasterLeave(currentTarget);
            currentTarget = null;
        }
    }

    protected virtual void OnRaycasterEnter(GameObject target)
    {

    }

    protected virtual void OnRaycasterLeave(GameObject target)
    {

    }

    protected virtual void OnRaycaster(GameObject target)
    {

    }
}
