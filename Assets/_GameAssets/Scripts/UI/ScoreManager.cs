using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Incluir la librería de UI

public class ScoreManager : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    private void Update()
    {
        GetComponent<Text>().text = gameManager.GetScore().ToString();
    }
}
