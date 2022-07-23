using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// エンターキーを押した時タイトルに戻るスクリプト
/// </summary>
public class EnterBackTitle : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown("return")) {
            SceneManager.LoadScene("Title");
        }
    }
}
