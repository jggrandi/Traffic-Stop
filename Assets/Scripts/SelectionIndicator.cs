using UnityEngine;
using System.Collections;

public class SelectionIndicator : MonoBehaviour {

    //MouseManager mm;

    public GameObject selected;
	// Use this for initialization
	void Start () {
//		mm = GameObject.FindObjectOfType<MouseManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(selected != null) {
            //transform.LookAt(Camera.main.transform);
            GetComponentInChildren<Renderer>().enabled = true;

			Bounds bigBounds = selected.GetComponentInChildren<Renderer>().bounds;

			// This "diameter" only works correctly for relatively circular or square objects

			float padding = 2.0f;


			this.transform.position = new Vector3(bigBounds.center.x, bigBounds.center.y, bigBounds.center.z);
			this.transform.localScale = new Vector3( bigBounds.size.x*padding, bigBounds.size.y*padding, bigBounds.size.z*padding );
		}
		else {
			GetComponentInChildren<Renderer>().enabled = false;
		}
	}
}
 