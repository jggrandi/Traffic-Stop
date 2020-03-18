using UnityEngine;

interface ISelectionMode
{
    GameObject CandidateObject { get; set; }

    bool Exists();
}