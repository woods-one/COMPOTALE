using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームクリア時にBGMストップさせるスクリプト
/// </summary>

public class BgmStop : MonoBehaviour
{
    AudioSource audioSource;
    void Update()
    {
        if (Timer.countTime <= 0)
        {
            audioSource = this.GetComponent<AudioSource>();
            audioSource.Stop();
        }
    }
}
