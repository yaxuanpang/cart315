using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text scoreText;

    public int leftScore = 0;
    public int rightScore = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Auto-find TMP_Text if not assigned in Inspector
        if (scoreText == null)
        {
            scoreText = FindAnyObjectByType<TMP_Text>();
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddLeftScore(int amount = 1)
    {
        leftScore += amount;
        UpdateScoreText();
    }

    public void AddRightScore(int amount = 1)
    {
        rightScore += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = leftScore + " : " + rightScore;
        }
    }
}