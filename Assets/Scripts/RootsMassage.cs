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
    string clearText;
    void Start()
    {
      clearText = "";
      StartCoroutine(ByOneCharacter());
    }
    IEnumerator ByOneCharacter()
    {
        for(int i = 0; i < clearMessage.Length; i++){
            clearText = clearMessage.Substring(0, i);
            GetComponent<Text>().text = clearText;
            yield return new WaitForSeconds(0.04f);
        }
    }
}
