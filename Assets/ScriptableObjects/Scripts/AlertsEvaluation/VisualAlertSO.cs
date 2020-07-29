using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New VisualAlert", menuName = "AlertEvaluation/VisualAlert")]

public class VisualAlertSO : ScriptableObject
{
    public ColorVariable color;
    public float screenCoverage;
    public float effectFeather;
}
