using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Person", menuName ="Traffic-Stop/Person")]
public class Person : ScriptableObject
{
    public PersonInfo personInfo;
    public License license;
    public RecordsList records;
}
