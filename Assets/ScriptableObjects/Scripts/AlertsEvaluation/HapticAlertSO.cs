using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New HapticAlert", menuName ="AlertEvaluation/HapticAlert")]

public class HapticAlertSO : ScriptableObject
{
    public float frequency;
    public float amplitude;
}
