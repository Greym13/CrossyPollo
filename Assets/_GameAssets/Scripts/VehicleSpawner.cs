using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public GameObject[] vehicles;
    public float minCreationSpeed;
    public float maxCreationSpeed;
    private int vehicleIndex;
    private float speedCreation;
    // Start is called before the first frame update
    void Start()
    {
        //genera vehiculos aleatorios, uno por carril, repitiendose el mismo
        vehicleIndex = Random.Range(0, vehicles.Length);
        //hace que los vehiculos tengan una velocidad aleatoria entre x e y
        speedCreation = Random.Range(minCreationSpeed, maxCreationSpeed);
        InvokeRepeating("SpawnVehicle",0,speedCreation);
    }

    // Update is called once per frame
    void Update()
    { }
    private void SpawnVehicle()
    {
        //genera carriles aleaatorios entre los que se añadan a la lista
        Instantiate(vehicles[vehicleIndex], transform.position, transform.rotation);
    }
}
