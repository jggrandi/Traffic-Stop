using UnityEngine;

// Uses the object's TAG as comparison.

class TagSelector : MonoBehaviour
{
    // Tag's name. 
    [SerializeField]
    string TAG = "UISelectable";
    public GameObject CandidateObject { get => candidateObject; set => candidateObject = value; }

    private GameObject candidateObject;

    // Check if the object has the tag name. 
    public bool Exists()
    {
        return CandidateObject.CompareTag(TAG);
    }
}