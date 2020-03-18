using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New AlertElement", menuName ="Traffic-Stop/AlertElement")]

public class AlertElement : ScriptableObject
{
    public string description;
    public ColorVariable color;
}
