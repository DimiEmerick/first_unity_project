using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleController : MonoBehaviour
{
    public float speed = 5f;
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private GameObject ball;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball"); // Encontra o objeto da bola na cena
    }

    private void Update()
    {
        #region Player 2
        /* float direction = 0f;

        if (Input.GetKey(KeyCode.W)) direction = 1f;
        else if (Input.GetKey(KeyCode.S)) direction = -1f;

        if (direction != 0f)
        {
            Vector3 newPosition = transform.position + Vector3.up * direction * speed * Time.deltaTime;
            newPosition.y = Mathf.Clamp(newPosition.y, -4.4f, 4.4f);
            transform.position = newPosition;
        } */
        #endregion
        #region CPU
        if (ball != null)
        {
            float targetY = Mathf.Clamp(ball.transform.position.y, -4.20f, 4.20f); // Limita a posição Y do inimigo baseado na posição da bola
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed); // Se move gradualmente para a posição Y da bola
        }
        #endregion
    }
}
