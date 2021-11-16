using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトを触ると指定のURLが開かれるスクリプト
/// </summary>

public class URL : Token
{
    [SerializeField]
    private string url;

    public void OnMouseDown()
    {
       Application.OpenURL(url);
    }
}
