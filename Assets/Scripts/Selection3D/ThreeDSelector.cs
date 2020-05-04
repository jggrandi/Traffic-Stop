using System.Collections.Generic;
using UnityEngine;


// Uses the dot product to determine which object is being looked at.
// It tests all objects with the "Selectable" tag.
// The object with the highest value is selected. 

public class ThreeDSelector : MonoBehaviour
{
    // Tolerance that allows the user to be a little off. 
    [SerializeField] private float threshold = 0.97f;
    
    private GameObject selection;
   
    public void Check(Ray _ray)
    {
        selection = null;

        var _closest = 0f;
        
        // Verify  all "Selectable" objects.
        for (int i = 0; i < SceneConfigurator.Instance.selectables.Count; i++)
        {
            var _vector1 = _ray.direction;
            var _vector2 = SceneConfigurator.Instance.selectables[i].transform.position - _ray.origin;
        
            var _lookPercentage = Vector3.Dot(_vector1.normalized, _vector2.normalized);

            // Select the current object if the dot product between the ray provided and the object meets the conditions.
            if (_lookPercentage > threshold && _lookPercentage > _closest)
            {
                _closest = _lookPercentage;
                selection = SceneConfigurator.Instance.selectables[i];
            }
        }
    }

    public GameObject GetSelection()
    {
        return selection;
    }
}