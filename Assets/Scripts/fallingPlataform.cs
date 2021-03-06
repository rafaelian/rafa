// Bibliotecas do Unity que são carregadas assim que o arquivo C#, sem estás 03 bibliotecas o script não irá funcionar.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlataform : MonoBehaviour
{

    public float tempoQueda;

    private TargetJoint2D target;
    private BoxCollider2D boxcollider;
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxcollider = GetComponent<BoxCollider2D>();
    }

     
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("falling", tempoQueda);
        }

    }

    void falling()
   {
        target.enabled = false;
        boxcollider.isTrigger = true;
    }
    // destroi o obejeto quando entra em contato com um objeto de layer 6

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
    }

}
