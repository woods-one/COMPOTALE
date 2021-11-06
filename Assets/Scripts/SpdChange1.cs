using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdChange1 : Token
{
    void Update()
    {
        if(Bomb.gameover1 == 1){
           Enemy.dir = Random.Range(0, 89);
           SetVelocity(Enemy.dir, Enemy.spd);
           Bomb.gameover1 = 0;
        }
    }
}
