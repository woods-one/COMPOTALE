using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bomb : Token
{
    /// <summary>クリックされた時の処理</summary>
    private Action onClick;

    public AudioClip sound4;
    AudioSource audioSource;
    int sflag;
    int sflag2;
    bool flag = true;

    private bool isClickedBomb;

    public static int bombCount;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sflag = 0;
        sflag2 = 1;

        isClickedBomb = false;
        bombCount = 0;
        SetSize(SpriteWidth / 2, SpriteHeight / 2);
        float dir = UnityEngine.Random.Range(0, 359);
        float spd = 5;
        SetVelocity(dir, spd);
    }

    void Update()
    {
        Vector2 min = GetWorldMin();
        Vector2 max = GetWorldMax();
        if (X < min.x || max.x < X)
        {
            VX *= -1;
            ClampScreen();
        }
        if (Y < min.y || max.y < Y)
        {
            VY *= -1;
            ClampScreen();
        }
        
        if (sflag == sflag2 && flag)
        {
            audioSource.PlayOneShot(sound4);
            flag = false;
            sflag2++;
        }
        else if (sflag == sflag2 && !flag)
        {
            audioSource.PlayOneShot(sound4);
            flag = true;
            sflag2++;
        }
    }

    /// <summary>
    /// このキャラをクリックしたときの処理
    /// </summary>
    public void OnMouseDown()
    {
        isClickedBomb = true;
        Enemy.scr -= 50;
        sflag++;
        bombCount++;
        if(Enemy.scr < 0)Enemy.scr = 0;
        for (int i = 0; i < 32; i++)
        {
            Particle.Add(X, Y, 2);
        }
        onClick.Invoke();
    }

    /// <summary>
    /// クリックされた時の処理を登録
    /// </summary>
    public void RegisterOnclickCallback(Action onClick)
    {
        this.onClick = onClick;
    }
}
