using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopulateVehicleInfo : MonoBehaviour
{
    public Vehicle vehicle;
    private VehicleInfo vehicleInfo;
    private VehicleRegistration vehicleRegistration;
    


    public TextMeshProUGUI make;
    public TextMeshProUGUI model;
    public TextMeshProUGUI year;
    public TextMeshProUGUI vin;
    public TextMeshProUGUI plateNumber;
    public TextMeshProUGUI issueDate;
    public TextMeshProUGUI expirationDate;
    public TextMeshProUGUI inspectionStatus;
    public Image vehiclePicture;


    // Start is called before the first frame update
    void Start()
    {
        vehicleInfo = vehicle.basicInformation;
        vehicleRegistration = vehicle.registration;

        make.text = vehicleInfo.make;
        model.text = vehicleInfo.model;
        year.text = vehicleInfo.year.ToString();
        vin.text = vehicleRegistration.vin;
        plateNumber.text = vehicleRegistration.plateNumber;
        issueDate.text = vehicleRegistration.issueDate;
        expirationDate.text = vehicleRegistration.expirationDate;
        inspectionStatus.text = vehicleRegistration.inspectionStatus.description;
        inspectionStatus.color = vehicleRegistration.inspectionStatus.color.color;
        vehiclePicture.sprite = vehicleInfo.vehiclePicture;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
