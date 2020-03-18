using UnityEngine;

public class ThreeDSelectionManager : MonoBehaviour
{
    private IRayProvider _rayProvider;
    private ISelector _selector;

    public GameObject CurrentSelection { get; set; }
    public bool IsNewSelection { get; set; }

    private void Awake()
    {
        HandleInteractableArea.OnExitInteractableArea += ResetSelection;
        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
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
        _selector.Check(_rayProvider.CreateRay());
        _selectionCandidate = _selector.GetSelection();

        if (_selectionCandidate == null) return;
        if (!_selectionCandidate.GetComponent<AlertObject>().IsInteractable) return; //if the object gazed is not interactable yet
        if (_selectionCandidate == CurrentSelection) return;

        CurrentSelection = _selectionCandidate;
        IsNewSelection = true;
        
    }
}