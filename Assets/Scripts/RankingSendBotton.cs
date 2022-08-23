using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// 押したときログインとルート偏移を行うスクリプト
/// </summary>

public class RankingSendBotton : MonoBehaviour
{
    [SerializeField]
    GameMgr gameMgr;
    public void OnClick()
    {
        if(InputFieldManager.isNotUserNameNull){
            gameMgr.ClearRoot(RealCompota.shootCount, gameMgr.killCount);
            gameMgr.UserLogin(InputFieldManager.userName);
        }
    }
}
