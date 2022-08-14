using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// クローンコンポタくんと本物のコンポタくんを撃った結果によって変わるルートの文章を表示するスクリプト
/// </summary>

public class RootsMassage : MonoBehaviour
{
    [SerializeField]
    private string clearMessage;

    [SerializeField]
    private Text clearText;
    
    void Start()
    {
      StartCoroutine(ByOneCharacter());
    }
    
    IEnumerator ByOneCharacter()
    {
        for(int i = 0; i < clearMessage.Length; i++){
            clearText.text = clearMessage.Substring(0, i);
            yield return new WaitForSeconds(0.04f);
        }
    }
}
