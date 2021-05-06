using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public GameObject[] prefabsFloor;
    public int firstFloor;
    [Range(10,1000)]
    public int floorNumber;

    private float z = 2;
    void Start()
    {
        //Validaci�n
        if (firstFloor >= prefabsFloor.Length)
        {
            Debug.LogError("FloorGenerator: El �ndice es superior al tama�o del array");
            return;
        }
        //Proceso de creaci�n
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, z);
        Quaternion newRotation = Quaternion.Euler(0,GetRandomY(),0);
        Instantiate(prefabsFloor[firstFloor], newPosition, transform.rotation);
        for (int i = 0; i < floorNumber; i++)
        {
            z = z + 2;
            newPosition = new Vector3(transform.position.x, transform.position.y, z);
            int floorRandomIndex = Random.Range(0, prefabsFloor.Length);
            newRotation = Quaternion.Euler(0, GetRandomY(), 0);
            Instantiate(prefabsFloor[floorRandomIndex], newPosition, newRotation);
        }
    }
    float GetRandomY()
    {
        float yRotation = 0;
        float seed = Random.Range(0, 100);
        if (seed > 50)
        {
            yRotation = 180;
        }
        return yRotation;
    }
}

