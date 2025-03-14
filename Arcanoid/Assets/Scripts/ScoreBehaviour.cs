using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBehaviour : MonoBehaviour
{
    public static ScoreBehaviour instance;

    private float score = 0;
    [SerializeField]
    TextMeshProUGUI scoreLabel;
    [SerializeField]
    TextMeshProUGUI scoreLabel2;
    [SerializeField]
    TextMeshProUGUI scoreLabel3;
    [SerializeField]
    RomperBloques romperBloques;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        romperBloques = FindAnyObjectByType<RomperBloques>();
        RefreshLabelScore();
    }

    public void Score(float scorebloq)
    {
        score += scorebloq;
        RefreshLabelScore();
    }

    void RefreshLabelScore()
    {
        scoreLabel.text = score.ToString();
        scoreLabel2.text = score.ToString();
        scoreLabel3.text = score.ToString();
    }
}
