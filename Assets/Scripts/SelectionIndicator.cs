using UnityEngine;
using System.Collections;

public class SelectionIndicator : MonoBehaviour {

    public static GameObject selectedObject;
    GameObject objHighlighter;

	// Use this for initialization
	void Start () {
        if (gameObject.transform.childCount != 0)
            objHighlighter = gameObject.transform.GetChild(0).gameObject;
    }

    float padding = 2.0f;
    // Update is called once per frame
    void Update () {
        if (selectedObject == null) return;
        if (selectedObject.name != "DriverLicense" && selectedObject.name != "Plate") return;
        
        //if (selectedObject.name == "DriverLicense") //temporary solution
        //    objHighlighter.transform.LookAt(Camera.main.transform);

        Bounds bigBounds = selectedObject.GetComponentInChildren<Renderer>().bounds;
        objHighlighter.transform.position = new Vector3(bigBounds.center.x, bigBounds.center.y, bigBounds.center.z);
        objHighlighter.transform.localScale = new Vector3(bigBounds.size.x * padding, bigBounds.size.y * padding, bigBounds.size.z * padding);

            //for (int i = 0; i < gameObject.transform.childCount; i++)
            //{
            //    //transform.LookAt(Camera.main.transform);
            //    //GetComponentInChildren<Renderer>().enabled = true;

            //    if (i == 1)// if it is the plate scanning object
            //        gameObject.transform.GetChild(i).transform.position = new Vector3(gameObject.transform.GetChild(i).transform.position.x, bigBounds.center.y, bigBounds.center.z);
            //    else
            //        gameObject.transform.GetChild(i).transform.position = new Vector3(bigBounds.center.x, bigBounds.center.y, bigBounds.center.z);
               
            //    plateHighlighter.transform.localScale = new Vector3(bigBounds.size.x * padding, bigBounds.size.y * padding, bigBounds.size.z * padding);
            //}
	
	}

}
 