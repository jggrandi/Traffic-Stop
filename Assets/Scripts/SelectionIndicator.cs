using UnityEngine;
using System.Collections;

public class SelectionIndicator : MonoBehaviour {

    //MouseManager mm;

    public GameObject selected;

    GameObject quad;
	// Use this for initialization
	void Start () {
        if(gameObject.transform.childCount != 0)
            quad = gameObject.transform.GetChild(0).gameObject;
    }

    float padding = 2.0f;
    // Update is called once per frame
    void Update () {
		if(selected != null) {

            Bounds bigBounds = selected.GetComponentInChildren<Renderer>().bounds;
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                //transform.LookAt(Camera.main.transform);
                //GetComponentInChildren<Renderer>().enabled = true;

                if (i == 1)// if it is the plate scanning object
                    gameObject.transform.GetChild(i).transform.position = new Vector3(gameObject.transform.GetChild(i).transform.position.x, bigBounds.center.y, bigBounds.center.z);
                else
                    gameObject.transform.GetChild(i).transform.position = new Vector3(bigBounds.center.x, bigBounds.center.y, bigBounds.center.z);
               
                quad.transform.localScale = new Vector3(bigBounds.size.x * padding, bigBounds.size.y * padding, bigBounds.size.z * padding);
            }
		}
		else {
			//GetComponentInChildren<Renderer>().enabled = false;
		}
	}
}
 