using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melon : MonoBehaviour
{

    private SpriteRenderer sprite;
    private CircleCollider2D collider;

    public GameObject coletado;

    public int Pontos;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D colision) 
    {
        if(colision.gameObject.tag == "Player")
       {     
            sprite.enabled = false;
            collider.enabled = false;

            coletado.SetActive(true);

            Savepoints.acesso.totalPontos += Pontos;

             Savepoints.acesso.atualizaPontosText();

            Destroy(gameObject, 0.4f);
        }
        
    }
}
