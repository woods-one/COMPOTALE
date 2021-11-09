using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using QuadrantType = DirectionUtility.QuadrantType;
using DirectionRange = DirectionUtility.DirectionRange;

/// <summary>
/// クローンコンポタくん（撃つべきキャラクタ）のスクリプト
/// </summary>

public class Enemy : Token
{
    /// <summary>移動方向（キャラごとにリセット時の方向範囲が決まっています）</summary>
    private QuadrantType velocityQuadrant;

    const int MaxSpd = 15;
    const int MinSpd = 1;
    const int DefaultSpeed = 7;

    public static int scr;
    public static int Count;
    public static int Count2;
    public AudioClip sound1;
    AudioSource audioSource;
    bool flag = true;
    private float spd;
    public static float dir;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scr = 0;
        Count = 0;
        Count2 = Count + 1;
        SetSize(SpriteWidth / 2, SpriteHeight / 2);
        dir = Random.Range(0, 359);
        // ������2
        spd = DefaultSpeed;
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
        if (Count == Count2 && flag)
        {
            audioSource.PlayOneShot(sound1);
            flag = false;
            Count2++;
        }
        else if (Count == Count2 && !flag)
        {
            audioSource.PlayOneShot(sound1);
            flag = true;
            Count2++;
        }
    }
    public void OnMouseDown()
    {

        int scrRandom = Random.Range(1,15);
        if(scrRandom < 6)scr += 10;
        else if(5 < scrRandom && scrRandom < 11)scr += 20;
        else if(10 < scrRandom && scrRandom < 13)scr += 30;
        else if(12 < scrRandom && scrRandom < 15)scr += 40;
        else scr += 100;
        Count++;
        for (int i = 0; i < 32; i++)
        {
        Particle.Add(X, Y, 1);
        }

        // 確率で増減
        bool shouldSpeedUP = Random.Range(0,4) == 0;
        if(!shouldSpeedUP)
        {
            spd += 1;
        }

        if(spd < MinSpd || spd > MaxSpd) spd = 7;

        dir = Random.Range(0, 359);
        
        SetVelocity(dir, spd);
    }

    /// <summary>
    /// 象限の設定
    /// </summary>
    public void SetVelocityQuadrant(QuadrantType velocityQuadrant)
    {
        this.velocityQuadrant = velocityQuadrant;
    }

    /// <summary>
    /// 移動方向のリセット
    /// </summary>
    public void ResetDirection()
    {
        spd = DefaultSpeed;

        DirectionRange directionRange = DirectionUtility.GetDirectionRange(velocityQuadrant);
        float angle = Random.Range(directionRange.directionStart, directionRange.directionEnd);
        SetVelocity(angle, spd);
    }
}