using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopulateRecords : MonoBehaviour
{

    public RecordsList records;
    public Canvas canvasRecords;
    // Start is called before the first frame update
    void Start()
    {
        //THIS IS TEMPORARY.. IT IS JUST POPULATING THE EXISTING TEXT FIELDS ALREADY CREATED AS CANVAS CHILDREN
        int i = 0;
        foreach (Transform child in canvasRecords.transform)
        {
            child.GetComponent<TextMeshProUGUI>().text = records.records[i].date;
            child.GetComponent<TextMeshProUGUI>().color = records.records[i].alertLevel.color.color;
            child.GetChild(0).GetComponent<TextMeshProUGUI>().text = records.records[i].description;
            i++;
        }
    }

}
