using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 広告のバツ印を押したら広告が消えるスクリプト
/// </summary>
public class DeleteAdvertisement : MonoBehaviour
{
    [SerializeField]
    GameObject advertisement;
    
    public void OnMouseDown()
    {
        Destroy(advertisement);
        Destroy(this.gameObject);
    }
}
