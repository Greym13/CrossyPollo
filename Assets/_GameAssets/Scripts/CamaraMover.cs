using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMover : MonoBehaviour
{
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float z = transform.position.z + (distance * Time.deltaTime);
        transform.position =
            new Vector3(
                transform.position.x,
                transform.position.y,
                z);
    }
}
