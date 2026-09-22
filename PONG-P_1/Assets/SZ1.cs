using UnityEngine;
using UnityEngine.InputSystem;

public class SZ1 : MonoBehaviour
{

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
        if (Keyboard.current[Key.A].isPressed)
        {
            SetColor(activeColor);
        }
        else
        {
            SetColor(normalColor);
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
