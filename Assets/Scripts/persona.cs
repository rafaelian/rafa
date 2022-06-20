// Bibliotecas do Unity que são carregadas assim que o arquivo C#, sem estás 03 bibliotecas o script não irá funcionar.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
A função deste script no projeto é atribuir elementos ao personagem, como movimentação, verificar se ele encostou em algo que possa mata-lo e demais componentes, além de configurar os sprites de animação do jeito correto.
Métodos deste Script:
void Start();
void Update();
void Move();
void Jump();
void OnCollisionEnter2D();
void OnCollisionExit2D();
GameObject atribuido:
Player.
*/

// Classe criada junto do arquivo C# e deve conter restritamente o nome do arquivo.

public class persona : MonoBehaviour
{

    
 // Variáveis declaradas para posteriormente serem utilizadas em métodos e o prefixo "public" indica que poderá ser editada na interface do unity e o prefixo "private" indica que está variável só poderá ser acessada no script, variáveis do tipo float são variáveis que aceitam valores decimais, a vairável bool significa que é uma variável que trabalha com true or false, e as variáveis RigidBody 2D e Animator são componentes do Unity.
        public float Speed;
        public float jumpForce;
        private Rigidbody2D body;
      
        public bool isJumping, doubleJump;

        private Animator anime;

   // Método que é ativado uma vez apenas e é quando o jogo começa.
  
    void Start()
    {
// Nesta sintaxe o código está pegando os componentes Rigidbody2D e o Animator.

        body = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>(); 
    }

   // Método que é ativado uma vez a cada frame com o jogo ativo.
    void Update()
    {
        // Nesta sintaxe dois métodos estão sendo chamados para a movimentação do personagem principal.
        Move();
        Jump();
    }
      // Método que faz com que o personagem principal se locomova no eixo X de forma positiva e negativa.
       void Move()
     
    {
        // A sintaxe abaixo tem como funcionalidade capitar as teclas de movimentação, o Input.GetAxis("Horizontal", 0f, 0f) serve para pegar o eixo X.
      Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

       // O transform.position só funciona com Vector3.
     transform.position += movement * Time.deltaTime * Speed;

     // O módulo de cascata de if é o que determina a direção em que o personagem irá andar, o primeiro if movimenta o personagem no eixo X de forma positiva.

    if(Input.GetAxis("Horizontal") > 0f){
    
       anime.SetBool("Run", true);
       transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }   

     // O segundo if movimenta o personagem no eixo X de forma negativa.

    if(Input.GetAxis("Horizontal")  <0f){
    
       anime.SetBool("Run", true);
       transform.eulerAngles = new Vector3(0f, 180f, 0f);
       
    }


    // O terceiro if serve para não executar nenhum movimento e permanecer na animação idle caso nenhuma tecla de movimentação esteja sendo precionada.              
   if(Input.GetAxis("Horizontal") == 0f) {                               
     
          anime.SetBool("Run", false);
     }
    

    }
    // Método que executa a ação de pulo do personagem, no caso o movimentando no eixo Y de forma positiva
 void Jump()
    {
        
         // Para pular, usaremos o RigidBody para movimentar o personagem
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {

                  // Ativa a opção de pular duas vezes
                body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
            }
            else
            {
                if (doubleJump)
                {
                    // Impede de o personagen pule mais de duas vezes
                    body.AddForce(new Vector2(0f, jumpForce * 1f), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

     // Métodos para verificar se o personagem toca em algo.
    // Também corrige um problema de pular a cada vez que se pressiona a tecla espaço.


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
        }


        if(collision.gameObject.tag == "Espinhos")
        {   
            // Método criado na classe Save Points
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


       

