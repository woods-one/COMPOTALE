using UnityEngine;
using System.Collections;


/// <summary>
/// キャラクターを撃った時パーティクルを出すスクリプト（借り物）
/// </summary>

public class Particle : Token
{

    static GameObject _prefab = null;
    static GameObject _prefab2 = null;
    public static Particle Add(float x, float y, float z)
    {
        if(z == 1){
            _prefab = GetPrefab(_prefab, "Particle");
            return CreateInstance2<Particle>(_prefab, x, y);
        }
        else if(z == 2){
            _prefab2 = GetPrefab(_prefab2, "Particle2");
            return CreateInstance2<Particle>(_prefab2, x, y);
        }
        return null;
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