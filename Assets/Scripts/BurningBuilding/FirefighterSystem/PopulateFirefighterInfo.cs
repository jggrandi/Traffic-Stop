using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class PopulateFirefighterInfo : MonoBehaviour
{
    protected FireFighter person;
    private PersonInfo personInfo;

    public TextMeshProUGUI name;
    public TextMeshProUGUI dist;

    Color color;
    public Image mapDot;
    public Image helmetIcon;
    private int alertSpeed = 1;

    void Start()
    {
        FirefighterListener.ShowUI += PopulateUI;
        person = GetComponent<StoreFirefighterData>().data;
        color = person.color;
    }


    protected void PopulateInfo()
    {
        Utils.alpha = color.a;
        color = Utils.DefineFlashingColorBasedOnAlertCode(person.alertLevel, Utils.alpha, person.color,ref alertSpeed);
        if (person.isPlayer)
        {
            color = Color.cyan;
            mapDot.sprite = Resources.Load<Sprite>("Store");
            name.transform.parent.gameObject.SetActive(false);
        }
        mapDot.color = color;
        personInfo = person.personInfo;

        name.text = personInfo.firstName;
        dist.text = person.distance.ToString()+"'";
        name.color = color;
        dist.color = color;
        helmetIcon.color = color;
    }

    private void PopulateUI(GameObject _obj)
    {
        _obj = this.transform.gameObject;
        person = _obj.GetComponent<StoreFirefighterData>().data;
        if (person == null)
        {
            Debug.LogWarning("Person data attached to the game object");
            return;
        }
        PopulateInfo();
        Vector3 camPos = Camera.main.transform.position;
        dist.transform.parent.LookAt(new Vector3(camPos.x, 0, camPos.z));
    }

    public Color getCurrentColor()
    {
        return color;
    }
}
