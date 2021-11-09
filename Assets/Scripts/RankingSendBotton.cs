using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// 押したときログインとルート偏移を行うスクリプト
/// </summary>

public class RankingSendBotton : MonoBehaviour
{
    public void OnClick()
    {
        if(InputFieldManager.flag4){
            GameMgr.ClearRoot(RealCompotale.bombCount, Enemy.Count);
            var mc = new GameMgr();
            GameMgr.flag3 = true;
            mc.UserLogin(InputFieldManager.userName);
        }
    }
}
