using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Score") 
        {
            gameManager.AddScore(1);
            Destroy(other.gameObject);//asi se destruye la pared, no el pollo
        }
    }

}
