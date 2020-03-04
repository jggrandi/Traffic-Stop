using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertObject : MonoBehaviour
{
    public enum AlertLevel { none, low, medium, high };
    [SerializeField]
    AlertLevel alertLevel;

    [SerializeField]
    AlertsHandler.Type type;

    [SerializeField]
    bool isInteractable = false;

    public AlertsHandler.Type Type { get => type; set => type = value; }
    public AlertLevel LevelAlert { get => alertLevel; set => alertLevel = value; }
    public bool IsInteractable { get => isInteractable; set => isInteractable = value; }
}
