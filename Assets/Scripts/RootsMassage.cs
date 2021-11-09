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
    public string clearmessage;
    string cleartext;
    float cleartime;
    int cleartime2;
    int i;
    void Start()
    {
      i = 0;
      cleartext = "";
    }

    void FixedUpdate()
    {
        cleartime = Time.deltaTime;
        cleartime2 = (int)Mathf.Floor(cleartime);
        if(cleartime2 % 2 == 0)StartCoroutine(ByOneCharacter());
    }
    IEnumerator ByOneCharacter()
    {
        yield return new WaitForSeconds(0.5f);
        if(i < clearmessage.Length){
        cleartext = clearmessage.Substring(0, i);
        GetComponent<Text>().text = cleartext;
        i++;
        }
    }
}
