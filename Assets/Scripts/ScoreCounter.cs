using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text scoreText;
    private int _scoreMultiplier = 1;
    private int _score = 0;

    public int score
    {
        get
        {
            return _score;
        }
        set
        {
            _score += (value - _score) * scoreMultiplier;
            scoreText.text = score.ToString();
        }
    }
    public int scoreMultiplier
    {
        get
        {
            return _scoreMultiplier;
        }
        set
        {
            if (value > 2)
            {
                _scoreMultiplier = 1;
            }
            else
            {
                _scoreMultiplier = value;
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag("ColumnLine"))
        {
            score++;
        }
    }
}
