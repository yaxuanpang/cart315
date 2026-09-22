using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startingSpeed;

    public TMP_Text scoreText;
    private static int leftScore = 0;
    private static int rightScore = 0;

    void Start()
    {
        leftScore = 0;
        rightScore = 0;
        ResetBall();
    }

    void ResetBall()
    {
        // Move the ball back to center and stop old velocity
        transform.position = Vector2.zero;
        rb.linearVelocity = Vector2.zero;

        if (scoreText != null)
        {
            scoreText.text = leftScore + " : " + rightScore;
        }

              bool isRight = UnityEngine.Random.value >= 0.5;

        float xVelocity = -1f;
        if(isRight == true)
        {
            xVelocity = 1f;
        }

        float yVelocity = UnityEngine.Random.Range(-1f, 1f);

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
        if (hitObject.name == "ScoreZoneLeft" || hitObject.CompareTag("ScoreZoneLeft"))
        {
            rightScore++;
            ResetBall();
        }
        else if (hitObject.name == "ScoreZoneRight" || hitObject.CompareTag("ScoreZoneRight"))
        {
            leftScore++;
            ResetBall();
        }
    }
}