using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイ中にスコアを表示、クリア時に最終スコアを表示するスクリプト
/// </summary>

public class Score : MonoBehaviour
{
    public Text score;
    public Text scoreDis;
 
    void Update()
    {
        score.text = "SCORE: " + Enemy.score.ToString();
        scoreDis.text = "あなたのスコアは" + Enemy.score.ToString() + "点です！";
    }
}