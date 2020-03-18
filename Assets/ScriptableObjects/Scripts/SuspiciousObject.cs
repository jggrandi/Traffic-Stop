using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SuspiciousObject", menuName = "Traffic-Stop/SuspiciousObject")]
public class SuspiciousObject : ScriptableObject
{
    public string objInfo;
    public AlertElement alertLevel;
}
