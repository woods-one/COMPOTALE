using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// クローンコンポタくんと本物のコンポタくんを撃った結果によって変わるルートの文章を表示するスクリプト
/// </summary>
public class RootsMassage : MonoBehaviour
{
    [SerializeField]
    private string clearMessage;

    [SerializeField]
    private Text clearText;

    private float timeBetweenCharacter = 0.1f;
    
    void Start()
    {
        clearText.DOText(clearMessage, clearMessage.Length * timeBetweenCharacter).SetEase(Ease.Linear);
    }
}
