using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームクリア時にBGMストップさせるスクリプト
/// </summary>
public class BgmStop : MonoBehaviour
{
    [SerializeField]
    AudioSource mianBGM;
    
    void Update()
    {
        if (Timer.countTime <= 0)
        {
            mianBGM.Stop();
        }
    }
}
