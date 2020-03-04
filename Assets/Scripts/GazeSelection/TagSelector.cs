using UnityEngine;

class TagSelector : MonoBehaviour, ISelectionMode
{
    [SerializeField]
    string TAG = "UISelectable";

    private GameObject candidateObject;

    public GameObject CandidateObject { get => candidateObject; set => candidateObject = value; }

    public bool Exists()
    {
        return CandidateObject.CompareTag(TAG);
    }
}