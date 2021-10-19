using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URL : Token
{
    public string url;

    public void OnMouseDown()
    {
       Application.OpenURL(url);
    }
}
