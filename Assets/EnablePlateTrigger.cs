using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlateTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
            gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
