using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdChange1 : Token
{
    // Start is called before the first frame update
    void Update()
    {
        if(Bomb.gameover == 1){
           Enemy.dir = Random.Range(0, 89);
           SetVelocity(Enemy.dir, Enemy.spd);
           Bomb.gameover = 0;
        }
    }
}
