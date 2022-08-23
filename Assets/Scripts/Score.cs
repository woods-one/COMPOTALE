using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// プレイ中にスコアを表示、クリア時に最終スコアを表示するスクリプト
/// </summary>
public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    public Text scoreDis;
    
    public ReactiveProperty<int> score = new ReactiveProperty<int>();

    private int indicateScore = 0;
 
    void Update()
    {
        if(score.Value < 0)score.Value = 0;
        if(indicateScore < score.Value)indicateScore++;
        if(indicateScore > score.Value)indicateScore--;
        scoreText.text = $"SCORE: {indicateScore}";
        scoreDis.text = $"あなたのスコアは{score.Value}";
    }
}