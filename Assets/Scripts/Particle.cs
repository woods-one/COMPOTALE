using UnityEngine;
using System;
using System.Collections;

using Random = UnityEngine.Random;


/// <summary>
/// キャラクターを撃った時パーティクルを出すスクリプト（借り物）
/// </summary>
public class Particle : Token
{
    enum Particles
    {
        OriginalCompotaParticle,
        CloneCompotaParticle
    }

    static GameObject particlePrefab;

    private const int MinDirectionRange = 0;
    private const int MaxDirectionRange = 359;

    private float MinParticleSpeed = 10.0f;
    private float MaxParticleSpeed = 20.0f;

    private float minScaleX = 0.01f;

    private float waitSeconds = 0.01f;

    private float rateChangeScale = 0.9f;
    private float rateChangeSpeed = 0.9f;

    public static Particle Add(float x, float y, int z)
    {
        particlePrefab = null;
        particlePrefab = GetPrefab(particlePrefab, Enum.GetName(typeof(Particles), z));
        return CreateInstance2<Particle>(particlePrefab, x, y);
    }
    IEnumerator Start()
    {
        float dir = Random.Range(MinDirectionRange, MaxDirectionRange);
        float spd = Random.Range(MinParticleSpeed, MaxParticleSpeed);
        SetVelocity(dir, spd);

        while (ScaleX > minScaleX)
        {
            yield return new WaitForSeconds(waitSeconds);
            MulScale(rateChangeScale);
            MulVelocity(rateChangeSpeed);
        }
        DestroyObj();
    }
}