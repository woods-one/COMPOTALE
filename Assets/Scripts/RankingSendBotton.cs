using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// 押したときログインとルート偏移を行うスクリプト
/// </summary>

public class RankingSendBotton : MonoBehaviour
{
    GameMgr gameMgr;
    public void OnClick()
    {
        gameMgr = new GameMgr();
        if(InputFieldManager.flag4){
            gameMgr.ClearRoot(RealCompota.shootCount, Enemy.killCount);
            gameMgr.UserLogin(InputFieldManager.userName);
        }
    }
}
