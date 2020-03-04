using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneConfigurator : MonoBehaviour
{

    public List<GameObject> allObjects;

    [SerializeField]
    private GameObject currentObject;

    private static SceneConfigurator _instance;
    public static SceneConfigurator Instance { get { return _instance; } }

    public GameObject CurrentObject { get => currentObject; set => currentObject = value; }

    public bool IsObjectInList(GameObject _obj)
    {
        GameObject g =  allObjects.Find(x => x.gameObject == _obj);
        if (g != null) return true;
        return false;
    }
    public GameObject GetObjectInList(AlertsHandler.Type _objType)
    {
        GameObject g = allObjects.Find(x => x.gameObject.GetComponent<AlertObject>().Type == _objType);
        if (g != null) return g;
        return null;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        AlertObject[] objs = GameObject.FindObjectsOfType<AlertObject>();
        for (int i = 0; i < objs.Length; i++)
            allObjects.Add(objs[i].gameObject);

        GrabDriversLicense.OnHoldLicense += EnableLicenseScan;
        UIGuider.OnCheckingVehiclePhase += EnablePlateScan;
    }

    private void EnableLicenseScan()
    {
        GameObject g = GetObjectInList(AlertsHandler.Type.license);
        g.GetComponent<AlertObject>().IsInteractable = true;
    }

    private void EnablePlateScan()
    {
        GameObject g = GetObjectInList(AlertsHandler.Type.plate);
        g.GetComponent<AlertObject>().IsInteractable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha6))
            CurrentObject = null;
        if (Input.GetKeyUp(KeyCode.Alpha7))
            CurrentObject = allObjects[0];
        if (Input.GetKeyUp(KeyCode.Alpha8))
            CurrentObject = allObjects[1];
        if (Input.GetKeyUp(KeyCode.Alpha9))
            CurrentObject = allObjects[2];
        if (Input.GetKeyUp(KeyCode.Alpha0))
            CurrentObject = allObjects[3];

        if (Input.GetKeyUp(KeyCode.Q))
            CurrentObject.GetComponent<AlertObject>().LevelAlert = AlertObject.AlertLevel.none;
        if (Input.GetKeyUp(KeyCode.W))
            CurrentObject.GetComponent<AlertObject>().LevelAlert = AlertObject.AlertLevel.low;
        if (Input.GetKeyUp(KeyCode.E))
            CurrentObject.GetComponent<AlertObject>().LevelAlert = AlertObject.AlertLevel.medium;
        if (Input.GetKeyUp(KeyCode.R))
            CurrentObject.GetComponent<AlertObject>().LevelAlert = AlertObject.AlertLevel.high;

        if (Input.GetKeyUp(KeyCode.M))
            CurrentObject.GetComponent<AlertObject>().IsInteractable = !CurrentObject.GetComponent<AlertObject>().IsInteractable;
    }
}
