using UnityEngine;
using System.Collections;

public class Enemy : Token
{
    public static int scr;
    public static int Count;
    public static int Count2;
    public AudioClip sound1;
    AudioSource audioSource;
    bool flag = true;
    public static float spd;
    public static float dir;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scr = 0;
        Count = 0;
        Count2 = Count + 1;
        SetSize(SpriteWidth / 2, SpriteHeight / 2);
        dir = Random.Range(0, 359);
        spd = 7;
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
        int probability = Random.Range(1, 5);
        if(probability < 2)spd += 1;
        else if(probability > 4 )spd -= 1;
        if(spd < 1)spd = 7;
        else if(spd > 15)spd = 7;
        dir = Random.Range(0, 359);
        
        SetVelocity(dir, spd);
    }

}