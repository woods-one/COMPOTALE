using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 広告のバツ印を押したら広告が消えるスクリプト
/// </summary>

public class DeleteAdvertisement : MonoBehaviour
{
    [SerializeField]
    private string advertisementName;
    GameObject advertisement;
    void Start()
    {
        advertisement = GameObject.Find(advertisementName);
    } 
    public void OnMouseDown()
    {
        this.gameObject.SetActive(false);
        advertisement.SetActive(false); 
    }
}
