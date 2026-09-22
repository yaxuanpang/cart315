using UnityEngine;
using UnityEngine.InputSystem;

public class P2 : MonoBehaviour
{
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure a keyboard is connected before reading

        if (Keyboard.current == null) return;

        bool isPressingUp = Keyboard.current[Key.UpArrow].isPressed;
        bool isPressingDown = Keyboard.current[Key.DownArrow].isPressed;

        if (isPressingUp)
        {
            transform.Translate(Vector2.up *  Time.deltaTime * moveSpeed);
        }
        if (isPressingDown)
        {
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
        }
    }
}

