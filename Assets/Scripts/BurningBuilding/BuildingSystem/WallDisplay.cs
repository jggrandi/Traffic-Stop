using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Valve.VR.InteractionSystem;


public class WallDisplay : MonoBehaviour
{
    Vector3 hitNormal;
    private Plane[] planes;

    [SerializeField]
    private TextMeshProUGUI roomNumber;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private RoomListener roomBehind;
    void Start()
    {
    }

    private void Update()
    {
        if (inSight(this.GetComponent<Collider>()))
        {
            roomNumber.text = roomBehind.currentRoomNumber == 0 ? "" : roomBehind.currentRoomNumber.ToString();
            if (isViewCenter() && !inSight(roomNumber.GetComponent<Collider>()))
            {
                Transform(roomNumber.transform.gameObject);
            }
        }
        else
        {
            roomNumber.text = "";
        }
    }

    public void Transform(GameObject _obj)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit,
            Mathf.Infinity, layerMask))
        {

            // move the note to the intersection of ray and plane
            _obj.transform.position = new Vector3(hit.point.x, _obj.transform.position.y, hit.point.z);
            //// get the normal of the wall pointing
            //hitNormal = -hit.normal;
            //// align self to the normal of the wall pointing
            //transform.rotation = Quaternion.FromToRotation(Vector3.forward, hitNormal);
            //// self rotate along y axis to make display face to the camera
            //if (hit.normal.z > 0)//the normal of the wall pointing has same forward direction as camera
            //{
            //    transform.rotation = Quaternion.FromToRotation(Vector3.forward, absVec3(hitNormal));
            //    // display's forward direction should be opposite to the camera's forward
            //    transform.Rotate(0, 180f, 0, Space.Self);
            //}
            //else
            //{
            //    transform.rotation = Quaternion.FromToRotation(Vector3.forward, hitNormal);
            //}
            //// avoid the renderer overlap
            //transform.Translate(-Vector3.forward * 0.0001f);
        }
    }

    // whether the display is in the view
    private bool inSight(Collider _col)
    {
        planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        return GeometryUtility.TestPlanesAABB(planes, _col.bounds);
    }

    private Vector3 absVec3(Vector3 a)
    {
        return new Vector3(Mathf.Abs(a.x), Mathf.Abs(a.y), Mathf.Abs(a.z));
    }

    // whether the wall (holder of this script) is at the center of view
    private bool isViewCenter()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit,
            Mathf.Infinity, layerMask))
        {
            return hit.collider.transform == this.transform;
        }
        return false;
    }
}
