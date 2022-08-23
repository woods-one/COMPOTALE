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
    
    public static int killCount;
    
    [SerializeField]
    private AudioClip soundKillEnemy;
    
    [SerializeField]
    AudioSource audioSource;
    
    private bool isKillEnemy = false;
    private float speed;
    private float dir;//direction
    
    private int minDirRange = 0;
    private int maxDirRange = 359;

    private int minScrRange = 1;
    private int maxScrRange = 16;

    private int particleNum = 32;

    private int minSpeedUPRandom = 0;
    private int maxSpeedUPRandom = 4;

    [SerializeField]
    private Score scoreCom;

    void Start()
    {
        scoreCom.score.Value = 0;
        killCount = 0;
        
        SetSize(SpriteWidth / 2, SpriteHeight / 2);
        dir = Random.Range(minDirRange, maxDirRange);
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
        int scrRandom = Random.Range(minScrRange, maxScrRange);
        
        if(scrRandom < 6)scoreCom.score.Value += 10;
        else if(scrRandom < 11)scoreCom.score.Value += 20;
        else if(scrRandom < 13)scoreCom.score.Value += 30;
        else if(scrRandom < 15)scoreCom.score.Value += 40;
        else scoreCom.score.Value += 100;
        
        killCount++;
        
        for (int i = 0; i < particleNum; i++)
        {
            Particle.Add(X, Y, 0);
        }

        // 確率で増減
        bool shouldSpeedUP = Random.Range(minSpeedUPRandom,maxSpeedUPRandom) == 0;
        if(!shouldSpeedUP)
        {
            speed += 1;
        }

        if(speed < MinSpeed || speed > MaxSpeed) speed = DefaultSpeed;

        dir = Random.Range(minDirRange, maxDirRange);
        
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