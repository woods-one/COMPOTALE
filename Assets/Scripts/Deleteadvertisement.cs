using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleteadvertisement : Token
{
    GameObject kosenadvertisement;
    GameObject batu;
    void Start()
    {
        kosenadvertisement = GameObject.Find("kosenadvertisement");
        batu = GameObject.Find("batu");
    }
    public void OnMouseDown()
    {
       kosenadvertisement.SetActive(false);
       batu.SetActive(false);
    }
}
