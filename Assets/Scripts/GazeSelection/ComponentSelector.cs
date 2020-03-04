using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentSelector : MonoBehaviour, ISelectionMode
{
    [SerializeField]
    Button button;
    private GameObject candidateObject;


    public GameObject CandidateObject { get => candidateObject; set => candidateObject = value; }

    public bool Exists()
    {
        return CandidateObject.GetComponent<Button>();
    }

}
