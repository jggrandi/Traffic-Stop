using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertObject : MonoBehaviour
{
    public enum ObjType { plate, license, obj };
    public enum AlertLevel { none = 0, low =1, medium=2, high=3 };
    [SerializeField]
    AlertLevel alertLevel;

    [SerializeField]
    ObjType type;

    [SerializeField]
    bool isInteractable = false;

    public ObjType Type { get => type; set => type = value; }
    public AlertLevel LevelAlert { get => alertLevel; set => alertLevel = value; }
    public bool IsInteractable { get => isInteractable; set => isInteractable = value; }

}
