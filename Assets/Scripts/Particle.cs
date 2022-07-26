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
    public static Particle Add(float x, float y, int z)
    {
        particlePrefab = null;
        particlePrefab = GetPrefab(particlePrefab, Enum.GetName(typeof(Particles), z));
        return CreateInstance2<Particle>(particlePrefab, x, y);
    }
    IEnumerator Start()
    {
        float dir = Random.Range(0, 359);
        float spd = Random.Range(10.0f, 20.0f);
        SetVelocity(dir, spd);

        while (ScaleX > 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            MulScale(0.9f);
            MulVelocity(0.9f);
        }
        DestroyObj();
    }
}