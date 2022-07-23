using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// スタートのボタンを押すとゲームのメイン画面に偏移するスクリプト
/// </summary>

public class OnTitleStartBotton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Explanation");
    }
}

