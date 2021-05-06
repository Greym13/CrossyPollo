using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public float speed;
    // Update is called once per frame
    void Update()
    {
        //con esto se mueve a la misma velocidad en todos los dispositivos
        transform.Translate(Vector3.forward * speed * Time.deltaTime);    
    }
    private void OnTriggerEnter(Collider other)
    {
        //con esto se destruye al tocar un box collider
        if (other.gameObject.name == "EndWall")
        {
            Destroy(gameObject);
        }
        /*else if(other.gameObject.name == "Camion")
        {
            print("dead");
        }*/
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            other.gameObject.GetComponent<Player>().kill();
            print("dead");
        }
    }
}
