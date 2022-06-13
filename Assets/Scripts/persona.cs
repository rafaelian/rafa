using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persona : MonoBehaviour
{
    // Start is called before the first frame update
    
        public float Speed;
        public float jumpForce;
        private Rigidbody2D body;
      
        public bool isJumping, doubleJump;

        private Animator anime;

    // Update is called once per frame
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

       void Move()
     
    {

    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
     transform.position += movement * Time.deltaTime * Speed;


    if(Input.GetAxis("Horizontal") > 0f){
    
       anime.SetBool("Run", true);
       transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }   

    if(Input.GetAxis("Horizontal")  <0f){
    
       anime.SetBool("Run", true);
       transform.eulerAngles = new Vector3(0f, 180f, 0f);
       
    }


     
   if(Input.GetAxis("Horizontal") == 0f) {                               
     
          anime.SetBool("Run", false);
     }
    

    }

 void Jump()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {

                body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
            }
            else
            {
                if (doubleJump)
                {
            
                    body.AddForce(new Vector2(0f, jumpForce * 1f), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
        }


        if(collision.gameObject.tag == "Espinhos")
        {   
            Savepoints.acesso.ShowGameOver();
            Destroy(gameObject);
            
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}


       

