using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdChange4 : Token
{
    void Update()
    {
        if(Bomb.gameover4 == 1){
           Enemy.dir = Random.Range(270, 359);
           SetVelocity(Enemy.dir, Enemy.spd);
           Bomb.gameover4 = 0;
        }
    }
}
