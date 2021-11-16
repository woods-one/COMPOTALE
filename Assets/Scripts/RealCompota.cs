using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 本物のコンポタくん（撃ってはいけないキャラクタ）のスクリプト
/// </summary>
public class RealCompota : Token
{
    /// <summary>クリックされた時の処理</summary>
    private Action onClick;

    [SerializeField]
    private AudioClip soundShootRealCompota;
    AudioSource audioSource;
    bool isShootRealCompota;

    private bool isClickedBomb;

    public static int shootCount;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isShootRealCompota = false;
        isClickedBomb = false;
        shootCount = 0;
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
        
        if (isShootRealCompota)
        {
            audioSource.PlayOneShot(soundShootRealCompota);
            isShootRealCompota = false;
        }
    }

    /// <summary>
    /// このキャラをクリックしたときの処理
    /// </summary>
    public void OnMouseDown()
    {
        isClickedBomb = true;
        Enemy.score -= 50;
        isShootRealCompota = true;
        shootCount++;
        if(Enemy.score < 0)Enemy.score = 0;
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
