using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public Rigidbody rigidBody;
    public AudioSource audioSource;
    //para que se vaya modificando el sonido y no se repita el mismo siempre
    [Header("------Sound Configuration------")]
    public AudioClip[] jumpSounds;
    [Space(5)]
    public AudioClip[] scoreSounds;
    [Space(5)]
    [Range(0.9f, 1)]
    public float minPitch;
    [Range(1f, 1.1f)]
    public float maxPitch;
    //Para generar el movimiento en cada eje
    public float impulsoX;
    public float impulsoY;
    public float impulsoZ;
    public GameObject prefabExplosion;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        //Para añadir la fuerza, lo que lo mueve. los transform.localrotation hace que se gire en la direccion que quieras la primera vez
        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.y) > 0.1f) return;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Jump(0, 1, 1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            Jump(1, 1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            Jump(-1, 1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            Jump(0, 1, -1);
        }
        
    }

    void Jump(float x, float y,float z)
    {
        transform.SetParent(null);
        //para randomizar audios
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        //con esto suena
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(jumpSounds[Random.Range(0,jumpSounds.Length)]);
        //con esto salta
        Vector3 vectorSalto = new Vector3(x * impulsoX,y * impulsoY,z * impulsoZ);
        //print("IMPULSO Y:" + (y * impulsoY));
        rigidBody.AddForce(vectorSalto);
    }

    //Para que los coches maten al pollo
    public void kill()
    {
        Instantiate(prefabExplosion, transform.position, transform.rotation);
        gameManager.StartGameOver();
        Destroy(gameObject);
    }
}
