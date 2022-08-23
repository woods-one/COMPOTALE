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
            ClearRoot(RealCompota.shootCount, gameMgr.killCount);
            gameMgr.UserLogin(InputFieldManager.userName);
        }
    }
    
    private void ClearRoot(int x, int y)
    {
        if(x == 0 && y == 0)SceneManager.LoadScene("Proot");
        else if(x == 0 && 35 <= y)SceneManager.LoadScene("Troot");
        else if(0 < x && 40 <= y)SceneManager.LoadScene("Groot");
        else if(x == 0 && y < 35)SceneManager.LoadScene("Nroot");
        else if(0 < x && y < 40 && y != 0)SceneManager.LoadScene("Croot");
        else if(0 < x && y == 0)SceneManager.LoadScene("Broot");
    }
    
}
