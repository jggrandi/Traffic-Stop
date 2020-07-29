using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneConfigurator : MonoBehaviour
{

    public List<GameObject> selectables;

    //[SerializeField]
    //private GameObject currentObject;

    private static SceneConfigurator _instance;
    public static SceneConfigurator Instance { get { return _instance; } }

    //public GameObject CurrentObject { get => currentObject; set => currentObject = value; }

    public bool IsObjectInList(GameObject _obj)
    {
        GameObject g =  selectables.Find(x => x.gameObject == _obj);
        if (g != null) return true;
        return false;
    }
    public GameObject GetObjectInList(AlertObject.ObjType _objType)
    {
        GameObject g = selectables.Find(x => x.gameObject.GetComponent<AlertObject>().Type == _objType);
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
            selectables.Add(objs[i].gameObject);

        GrabDriversLicense.OnHoldLicense += EnableLicenseScan;
        UIGuider.OnCheckingVehiclePhase += EnablePlateScan;
    }

    private void EnableLicenseScan()
    {
        GameObject g = GetObjectInList(AlertObject.ObjType.license);
        g.GetComponent<AlertObject>().IsInteractable = true;
    }

    private void EnablePlateScan()
    {
        GameObject g = GetObjectInList(AlertObject.ObjType.plate);
        g.GetComponent<AlertObject>().IsInteractable = true;
    }

    public void SetPlateAlert(int _level)
    {
        GameObject g = GetObjectInList(AlertObject.ObjType.plate);
        SetAlert(g, (AlertObject.AlertLevel)_level);
    }

    public void SetLicenseAlert(int _level)
    {
        GameObject g = GetObjectInList(AlertObject.ObjType.license);
        SetAlert(g, (AlertObject.AlertLevel)_level);
    }

    public void SetObjectAlert(int _level)
    {
        GameObject g = GetObjectInList(AlertObject.ObjType.obj);
        SetAlert(g, (AlertObject.AlertLevel)_level);
    }

    public void SetAlert(GameObject _g, AlertObject.AlertLevel _l)
    {
        if (_g == null) return;
        _g.GetComponent<AlertObject>().LevelAlert = _l;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeInHierarchy);
    }
}
