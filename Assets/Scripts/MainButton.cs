using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    public void OnClick()
    {
        if(InputFieldManager.flag4){
            GameMgr.ClearRoot(Bomb.bombCount, Enemy.Count);
            var mc = new GameMgr();
            GameMgr.flag3 = true;
            mc.UserLogin(InputFieldManager.userName);
        }
    }
}
