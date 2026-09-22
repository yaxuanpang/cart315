using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startingSpeed = 7.5f;

    void Start()
    {
        ResetBall();
    }

    void ResetBall()
    {
         // Move the ball back to center and stop old velocity
        transform.position = Vector2.zero;
        rb.linearVelocity = Vector2.zero;

              bool isRight = UnityEngine.Random.value >= 0.5;

        float xVelocity = -1.5f;
        if(isRight == true)
        {
            xVelocity = 1.5f;
        }

        float yVelocity = UnityEngine.Random.Range(-1.5f, 1.5f);

        rb.linearVelocity = new Vector2(xVelocity * startingSpeed, yVelocity * startingSpeed);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        HandleScore(other.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleScore(collision.gameObject);
    }

    void HandleScore(GameObject hitObject)
    {
        if (hitObject.name.Contains("ScoreZoneRight") || hitObject.CompareTag("ScoreZoneRight"))
        {
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddLeftScore(1);
            }
            ResetBall();
        }
        else if (hitObject.name.Contains("ScoreZoneLeft") || hitObject.CompareTag("ScoreZoneLeft"))
        {
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddRightScore(1);
            }
            ResetBall();
        }
    }
}