using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Token
{
    public AudioClip sound4;
    AudioSource audioSource;
    int sflag;
    int sflag2;
    bool flag = true;
    public static int gameover1;
    public static int gameover2;
    public static int gameover3;
    public static int gameover4;
    public static int bombCount;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sflag = 0;
        sflag2 = 1;
        gameover1 = 0;
        gameover2 = 0;
        gameover3 = 0;
        gameover4 = 0;
        bombCount = 0;
        SetSize(SpriteWidth / 2, SpriteHeight / 2);
        float dir = Random.Range(0, 359);
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
    public void OnMouseDown()
    {
        gameover1 = 1;
        gameover2 = 1;
        gameover3 = 1;
        gameover4 = 1;
        Enemy.spd = 6;
        Enemy.scr -= 50;
        sflag++;
        bombCount++;
        if(Enemy.scr < 0)Enemy.scr = 0;
        for (int i = 0; i < 32; i++)
        {
            Particle.Add(X, Y, 2);
        }
    }
}
