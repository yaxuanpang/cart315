using UnityEngine;

public class ball : MonoBehaviour
{
    //variables
    private Rigidbody2D _rigidBody;
    public float speed = 100.0f;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Start()
    {
        float x = 0.0f;//need 2 have f for float
        float y = 0.0f;

        if(Random.value < 0.5f) x = -1.0f;//it will move the ball left
        else x = 1.0f;//it will move the ball right

        if(Random.value < 0.5f) y = -1.0f;//it will move the ball down
        else y = 1.0f;//it will move the ball up

        y = y * Random.Range(0.5f, 0.9f);//it will move the ball up or down randomly

        Vector2 force = new Vector2(x, y);

        _rigidBody.AddForce(force * speed);//adding force to the rigidbody (move ball)
    }
}
