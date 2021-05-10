using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMover : MonoBehaviour
{
    public float distance;
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
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMover : MonoBehaviour
{
    [Space(10)]
    [Header("Objeto al que sigue la camara")]
    public GameObject follow;

    void Update()
    {
        transform.position =
             new Vector3(
                 transform.position.x,
                 transform.position.y,
                 follow.transform.position.z); // La camara toma el valoz Z del Pollo
    }
}*/
