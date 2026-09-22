using UnityEngine;
using UnityEngine.InputSystem;

public class P2 : MonoBehaviour
{
    public float moveSpeed;

        [Header("Color Settings")]
    public Color normalColor = Color.pink;
    public Color activeColor = Color.blue;

    private SpriteRenderer sr;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = normalColor;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure a keyboard is connected before reading

        if (Keyboard.current == null) return;

        bool isPressingUp = Keyboard.current[Key.UpArrow].isPressed;
        bool isPressingDown = Keyboard.current[Key.DownArrow].isPressed;

        if (Keyboard.current[Key.RightArrow].isPressed)
        {
            SetColor(activeColor);
        }
        else
        {
            SetColor(normalColor);
        }

        if (isPressingUp)
        {
            transform.Translate(Vector2.up *  Time.deltaTime * moveSpeed);
        }
        if (isPressingDown)
        {
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
        }
    }
     public void SetColor(Color newColor)
    {
        if (sr != null)
        {
            sr.color = newColor;
        }
    }
}

