using System.Collections.Generic;
using UnityEngine;

public class ThreeDSelector : MonoBehaviour, ISelector
{
    
    [SerializeField] private float threshold = 0.97f;
    
    private GameObject _selection;
   
    public void Check(Ray ray)
    {
        _selection = null;

        var closest = 0f;
        
        for (int i = 0; i < SceneConfigurator.Instance.selectables.Count; i++)
        {
            var vector1 = ray.direction;
            var vector2 = SceneConfigurator.Instance.selectables[i].transform.position - ray.origin;
        
            var lookPercentage = Vector3.Dot(vector1.normalized, vector2.normalized);

            if (lookPercentage > threshold && lookPercentage > closest)
            {
                closest = lookPercentage;
                _selection = SceneConfigurator.Instance.selectables[i];
            }
        }
    }

    public GameObject GetSelection()
    {
        return _selection;
    }
}