using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroDestructor : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.transform.root.gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<Player>().kill();
        }
    }
}
