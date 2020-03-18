using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Person Information", menuName ="Traffic-Stop/PersonInfo")]
public class PersonInfo : ScriptableObject
{
    public string firstName;
    public string lastName;
    public string birthDate;
    public string address;
    public string sex;
    public string height;
    public string eyes;
    public string hair;
    
    public Sprite picture;

}
