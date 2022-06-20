// Bibliotecas do Unity que são carregadas assim que o arquivo C#, sem estás 03 bibliotecas o script não irá funcionar
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bibliotecas do Unity que habilitam a edição de "User Interface" e "Scene Management".
using UnityEngine.UI; // Sem isso a interface nao funciona.
using UnityEngine.SceneManagement; // Bliblioteca pra gerenciar a cena.

/*
A função deste script no projeto receber a pontuação extraída dos objetos coletáveis, exibir a tela de game over e permitir que o personagem possa reiniciar a fase caso morra, além de ouras funções do User Interface.
Métodos deste script:
void Start();
public void atualizaPontosText();
public void ShowGameOver();
public void Restartgame();
GameObject atribuido:
Canva.
*/

// Classe criada junto do arquivo C# e deve conter restritamente o nome do arquivo.
public class Savepoints : MonoBehaviour
{
     // Variáveis públicas, a variável "int" significa que aceita apenas valores inteiros, e a variável de tipo "text" informa uma variável que vai interagir com o elemento texto do UI.
    public int totalPontos;
    public Text contador;

  // Variável pública com o prefixo "GameObject" que interagem com um elemento na hierarquia.
    public GameObject gameOver;

    // Variável pública que permite outros scripts a acessarem este script. 
    public static Savepoints acesso;
    
    // Método que é ativado uma vez apenas e é quando o jogo começa.
    void Start()
    {
         // A sintaxe abaixo permite que outros scripts tenham acesso aos elementos deste script.
        acesso = this;
    }

 // O método abaixo converte o valor inteiro da variável "totalPontos" para texto, para ser aceita no "text" do canva.
    public void atualizaPontosText() => contador.text = totalPontos.ToString();

 // O método abaixo exibe a tela de game over. É invocado na classe Player quando o personagem Player toca em algum objeto cuja tag está seta para "espinhos". Ver classe player.

    public void ShowGameOver()
    {
        gameOver.SetActive(true);        
    }

 // O método abaixo torna a função de reiniciar a fase quando um "GameObject" com tag "Player" for destruído.
    public void RestartGame(string level)
    {
      SceneManager.LoadScene(level);
    }
    


}
