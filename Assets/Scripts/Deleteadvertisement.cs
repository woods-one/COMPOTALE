using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 広告のバツ印を押したら広告が消えるスクリプト
/// </summary>

public class Deleteadvertisement : Token
{
    public string adver;
    public string Batu;
    GameObject advertisement;
    GameObject batu;
    void Start()
    {
        advertisement = GameObject.Find(adver);
        batu = GameObject.Find(Batu);
    } 
    public void OnMouseDown()
    {
        batu.SetActive(false);
        advertisement.SetActive(false); 
    }
}
