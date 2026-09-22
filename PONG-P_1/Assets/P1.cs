using UnityEngine;
using UnityEngine.InputSystem;

public class P1 : MonoBehaviour
{


    public float moveSpeed;

    [Header("Color Settings")]
    public Color normalColor = Color.blue;
    public Color activeColor = Color.pink;

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
        if (Keyboard.current == null) return;

        bool isPressingUp = Keyboard.current[Key.W].isPressed;
        bool isPressingDown = Keyboard.current[Key.S].isPressed;

        if (Keyboard.current[Key.A].isPressed)
        {
            SetColor(activeColor);
        }
        else
        {
            SetColor(normalColor);
        }


        if (isPressingUp)
        {
            transform.Translate(Vector2.up  * Time.deltaTime * moveSpeed);
        }
        if (isPressingDown)
        {
            transform.Translate(Vector2.down  * Time.deltaTime * moveSpeed);
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
