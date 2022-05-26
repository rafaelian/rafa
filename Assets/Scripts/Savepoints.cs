using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Savepoints : MonoBehaviour
{
    public int totalPontos;
    public Text contador;

    public GameObject gameOver;
    
    public static Savepoints acesso;
    // Start is called before the first frame update
    void Start()
    {
        acesso = this;
    }

    public void atualizaPontosText() => contador.text = totalPontos.ToString();

    public void ShowGameOver()
    {
        gameOver.SetActive(true);        
    }
    
}
