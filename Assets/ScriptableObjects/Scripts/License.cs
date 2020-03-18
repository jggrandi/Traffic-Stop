using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New License", menuName ="Traffic-Stop/License")]
public class License : ScriptableObject
{
    public string DLN;
    public string expirationDate;
    public string licenseClass;
    public AlertElement status;
}
