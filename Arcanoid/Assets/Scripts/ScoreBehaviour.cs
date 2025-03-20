using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBehaviour : MonoBehaviour
{
    public static ScoreBehaviour instance;

    private float score = 0;
    private float highScore = 0;

    [SerializeField] TextMeshProUGUI scoreLabel;
    [SerializeField] TextMeshProUGUI scoreLabel2;
    [SerializeField] TextMeshProUGUI scoreLabel3;
    [SerializeField] TextMeshProUGUI highScoreLabel;
    [SerializeField] RomperBloques romperBloques;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        romperBloques = FindAnyObjectByType<RomperBloques>();

        highScoreLabel.text = highScore.ToString();

        RefreshLabelScore();
    }

    public void Score(float scorebloq)
    {
        score += scorebloq;
        RefreshLabelScore();
        CheckHighScore();
    }

    void RefreshLabelScore()
    {
        scoreLabel.text = score.ToString();
        scoreLabel2.text = score.ToString();
        scoreLabel3.text = score.ToString();

        if (highScoreLabel != null)
            highScoreLabel.text = "Récord: " + highScore.ToString(); // Muestra el récord
    }

    void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            highScoreLabel.text = highScore.ToString();
        }
    }
}
