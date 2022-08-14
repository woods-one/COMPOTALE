using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// マウスをオブジェクトに重ねた時に影を付けるスクリプト
/// </summary>

public class MouseOver : MonoBehaviour
{
    [SerializeField]
    private string ShadowName;
    GameObject shadowObject;

    void Start()
    {
        shadowObject = GameObject.Find(ShadowName);
        shadowObject.SetActive(false);
    }
    void OnMouseEnter() 
    {
        shadowObject.SetActive(true);        
    }
    void OnMouseExit() {
        shadowObject.SetActive(false);
    }
}
