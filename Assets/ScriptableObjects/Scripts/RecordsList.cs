using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RecordsList", menuName = "Traffic-Stop/RecordsList")]
public class RecordsList : ScriptableObject
{
    public List<Record> records;
}
