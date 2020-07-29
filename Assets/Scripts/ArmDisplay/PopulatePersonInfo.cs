using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopulatePersonInfo : MonoBehaviour
{
    protected Person person;
    private PersonInfo personInfo;
    private  License license;

    public TextMeshProUGUI firstName;
    public TextMeshProUGUI lastName;
    public TextMeshProUGUI dob;
    public TextMeshProUGUI address;
    public TextMeshProUGUI sex;
    public TextMeshProUGUI hgt;
    public TextMeshProUGUI hair;
    public TextMeshProUGUI eyes;

    public TextMeshProUGUI licenseClass;
    public TextMeshProUGUI dln;
    public TextMeshProUGUI expirationDate;
    public TextMeshProUGUI licenseStatus;
    public Image picture;


    protected void PopulateInfo()
    {
        personInfo = person.personInfo;
        license = person.license;

        firstName.text = personInfo.firstName;
        lastName.text = personInfo.lastName;
        dob.text = personInfo.birthDate;
        address.text = personInfo.address;
        sex.text = personInfo.sex;
        hgt.text = personInfo.height;
        hair.text = personInfo.hair;
        eyes.text = personInfo.eyes;
        licenseClass.text = license.licenseClass;
        dln.text = license.DLN;
        expirationDate.text = license.expirationDate;
        licenseStatus.text = license.status.description;
        licenseStatus.color = license.status.color.color;
        picture.sprite = person.personInfo.picture;
    }

}
