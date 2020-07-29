using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FireFighter", menuName = "Burning-Building/FireFighter")]
public class FireFighter : ScriptableObject
{
    public PersonInfo personInfo;
    public int distance;
    public Color color;
    public AlertObject.AlertLevel alertLevel;
    public bool isPlayer;
    public int currentFloor;

}
