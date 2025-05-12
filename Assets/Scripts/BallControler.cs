using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControler : MonoBehaviour
{
    public Vector2 startingVelocity = new Vector2(5f, 5f);
    public GameManager gameManager;

    private Rigidbody2D rb;

    public void ResetBall()
    {
        transform.position = Vector3.zero; // Zera a posição da bola
        if (rb == null) rb = GetComponent<Rigidbody2D>(); // Pega o Rigidbody2D da bola
        rb.velocity = startingVelocity; // Adiciona a velocidade inicial no Rigidbody2D
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) // Se colidir com um objeto que contém a tag "Wall" (Parede)
        {
            Vector2 newVelocity = rb.velocity; // Cria uma variável com a nova velocidade e registra a velocidade atual da bola
            newVelocity.y = -newVelocity.y; // Inverte a velocidade vertical da bola ao colidir com uma parede
            rb.velocity = newVelocity; // Aplica essa nova velocidade na velocidade atual
        }

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy")) // Se colidir com um objeto que contém a tag "Player" ou "Enemy"
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y); // Adiciona uma nova velocidade invertendo horizontalmente mas mantendo a velocidade vertical
            rb.velocity *= 1.1f;
        }

        if (collision.gameObject.CompareTag("WallEnemy"))
        {
            gameManager.ScorePlayer();
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("WallPlayer"))
        {
            gameManager.ScoreEnemy();
            ResetBall();
        }
    }
}
