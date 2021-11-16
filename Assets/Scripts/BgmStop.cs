using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームクリア時にBGMストップさせるスクリプト
/// </summary>

public class BgmStop : MonoBehaviour
{
    AudioSource mianBGM;
    void Update()
    {
        if (Timer.countTime <= 0)
        {
            mianBGM = this.GetComponent<AudioSource>();
            mianBGM.Stop();
        }
    }
}
