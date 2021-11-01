using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public Text scoreDis;
 
    void Update()
    {
        score.text = "SCORE: " + Enemy.scr.ToString();
        scoreDis.text = "あなたのスコアは" + Enemy.scr.ToString() + "点です！";
    }
}