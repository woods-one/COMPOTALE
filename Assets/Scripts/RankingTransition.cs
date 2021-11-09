using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ランキング画面に偏移するスクリプト
/// </summary>

public class RankingTransition : MonoBehaviour
{
    public void OnMouseDown()
    {
       SceneManager.LoadScene("Ranking");
    }
}
