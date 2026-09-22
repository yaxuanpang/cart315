using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Blue : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startingSpeed = 10f;

    void Start()
    {
        ResetBluePosition();
    }

    void ResetBluePosition()
    {
        // Move the ball back to center and stop old velocity
        transform.position = Vector2.zero;
        rb.linearVelocity = Vector2.zero;

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
        if (hitObject.name.Contains("ScoreZoneRight") || hitObject.CompareTag("ScoreZoneRight"))
        {
            if (ScoreManager.Instance != null && Keyboard.current != null && (!Keyboard.current[Key.RightArrow].isPressed))
            {
                ScoreManager.Instance.AddLeftScore(1);
                ResetBluePosition();
            }
            ResetBluePosition();
        }
        else if (hitObject.name.Contains("ScoreZoneLeft") || hitObject.CompareTag("ScoreZoneLeft"))
        {
            if (ScoreManager.Instance != null && Keyboard.current != null && (Keyboard.current[Key.A].isPressed))
            {
                ScoreManager.Instance.AddRightScore(1);
            }
            ResetBluePosition();
            if (ScoreManager.Instance != null && Keyboard.current != null && (Keyboard.current[Key.RightArrow].isPressed))
            {
                ResetBluePosition();
            }
        }
    }
}