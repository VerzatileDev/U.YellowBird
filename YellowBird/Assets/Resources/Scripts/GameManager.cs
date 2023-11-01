using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTextInGame;
    [SerializeField] private TMP_Text scoreTextDeathUI;
    [SerializeField] private TMP_Text highScoreTextDeathUI;
    [SerializeField] AudioSource PointSound;
    private int score;
    private int highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreTextDeathUI.text = highScore.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        PointSound.Play();
        scoreTextInGame.text = score.ToString();
        scoreTextDeathUI.text = score.ToString();
        
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreText();
        }
    }

    private void UpdateHighScoreText()
    {
        highScoreTextDeathUI.text = highScore.ToString();
    }
}