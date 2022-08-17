using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイ中にスコアを表示、クリア時に最終スコアを表示するスクリプト
/// </summary>

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text score;
    [SerializeField]
    public Text scoreDis;

    private int indicateScore = 0;
 
    void Update()
    {
        if(indicateScore < Enemy.score)indicateScore++;
        if(indicateScore > Enemy.score)indicateScore--;
        score.text = $"SCORE: {indicateScore}";
        scoreDis.text = $"あなたのスコアは{Enemy.score}";
    }
}