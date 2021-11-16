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

    const int MaxSpeed = 15;
    const int MinSpeed = 1;
    const int DefaultSpeed = 7;

    public static int score = 0;
    public static int killCount = 0;
    [SerializeField]
    private AudioClip soundKillEnemy;
    AudioSource audioSource;
    private bool isKillEnemy = false;
    private float speed;
    public static float dir;//direction
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetSize(SpriteWidth / 2, SpriteHeight / 2);
        dir = Random.Range(0, 359);
        speed = DefaultSpeed;
        SetVelocity(dir, speed);
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
        if (isKillEnemy)
        {
            audioSource.PlayOneShot(soundKillEnemy);
            isKillEnemy = false;
        }
    }
    public void OnMouseDown()
    {
        isKillEnemy = true;
        int scrRandom = Random.Range(1,15);
        if(scrRandom < 6)score += 10;
        else if(5 < scrRandom && scrRandom < 11)score += 20;
        else if(10 < scrRandom && scrRandom < 13)score += 30;
        else if(12 < scrRandom && scrRandom < 15)score += 40;
        else score += 100;
        killCount++;
        for (int i = 0; i < 32; i++)
        {
        Particle.Add(X, Y, 1);
        }

        // 確率で増減
        bool shouldSpeedUP = Random.Range(0,4) == 0;
        if(!shouldSpeedUP)
        {
            speed += 1;
        }

        if(speed < MinSpeed || speed > MaxSpeed) speed = 7;

        dir = Random.Range(0, 359);
        
        SetVelocity(dir, speed);
    }

    /// <summary>
    /// 象限の設定
    /// </summary>
    public void SetVelocityQuadrant(QuadrantType velocityQuadrant)
    {
        this.velocityQuadrant = velocityQuadrant;
    }

    /// <summary>
    /// 速度と移動方向のリセット
    /// </summary>
    public void ResetDirection()
    {
        speed = DefaultSpeed;

        DirectionRange directionRange = DirectionUtility.GetDirectionRange(velocityQuadrant);
        float angle = Random.Range(directionRange.directionStart, directionRange.directionEnd);
        SetVelocity(angle, speed);
    }
}