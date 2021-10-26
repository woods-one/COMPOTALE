using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
