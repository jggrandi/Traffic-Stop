using UnityEngine;

// Controls the selection of 3D elements in the scene.

[RequireComponent(typeof(ThreeDSelector))]
public class ThreeDSelectionManager : MonoBehaviour
{
    public GameObject CurrentSelection { get; set; }
    public bool IsNewSelection { get; set; }

    // Controls how the rays will be generated.
    private IRayProvider rayProvider;
    
    // Controls how the elements will be selected.
    private ThreeDSelector selector;

    private void Awake()
    {
        // Reset the selection when player moves away from the vehicle.
        HandleInteractableArea.OnExitInteractableArea += ResetSelection;
        
        selector = GetComponent<ThreeDSelector>();
        
        // Currently using the VRCameraRayProvider script.
        rayProvider = GetComponent<IRayProvider>();

        ResetSelection();
    }

    private void OnDisable()
    {
        HandleInteractableArea.OnExitInteractableArea -= ResetSelection;
    }

    void ResetSelection()
    {
        CurrentSelection = null;
    }

    private void Update()
    {
        GameObject _selectionCandidate;
        IsNewSelection = false;
        selector.Check(rayProvider.CreateRay());
        _selectionCandidate = selector.GetSelection();

        if (_selectionCandidate == null) return;
        if (!_selectionCandidate.GetComponent<AlertObject>().IsInteractable) return; //if the object gazed is not interactable yet
        if (_selectionCandidate == CurrentSelection) return;

        CurrentSelection = _selectionCandidate;
        IsNewSelection = true;
        
    }
}