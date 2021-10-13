using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmStop : MonoBehaviour
{
    AudioSource audioSource;
    void Update()
    {
        if (Enemy.Count == 0 || Bomb.gameover == 1)
        {
            audioSource = this.GetComponent<AudioSource>();
            audioSource.Stop();
        }
    }
}
