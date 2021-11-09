using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// マウスをオブジェクトに重ねた時に影を付けるスクリプト
/// </summary>

public class MouseOver : MonoBehaviour
{
    public string ShadowName;
    GameObject Shadow;

    void Start()
    {
        Shadow = GameObject.Find(ShadowName);
        Shadow.SetActive(false);
    }
    void OnMouseEnter() 
    {
        Shadow.SetActive(true);        
    }
    void OnMouseExit() {
        Shadow.SetActive(false);
    }
}
