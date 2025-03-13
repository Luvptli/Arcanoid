using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBehaviour : MonoBehaviour
{
    private float score = 0;
    [SerializeField]
    TextMeshProUGUI scoreLabel;
    [SerializeField]
    TextMeshProUGUI scoreLabel2;
    [SerializeField]
    TextMeshProUGUI scoreLabel3;
    [SerializeField]
    RomperBloques romperBloques;

    //no me funciona
    void Start()
    {
        romperBloques = FindAnyObjectByType<RomperBloques>();
        RefreshLabelScore();
    }

    public void Score()
    {
        score += romperBloques.valor;
        RefreshLabelScore();
    }

    void RefreshLabelScore()
    {
        scoreLabel.text = score.ToString();
        scoreLabel2.text = score.ToString();
        scoreLabel3.text = score.ToString();
    }
}
