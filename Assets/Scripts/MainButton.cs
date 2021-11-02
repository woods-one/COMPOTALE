using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    void OnGUI()
    {
        // �t�H���g�̈ʒu
        float w = 128; // ��
        float h = 32; // ����
        float px = Screen.width / 2 - w / 2;
        float py = Screen.height / 2 - h / 2 + 210;

        if (GUI.Button(new Rect(px, py, w, h), "SEND") && InputFieldManager.flag4)
        {
            GameMgr.ClearRoot(Bomb.bombCount, Enemy.Count);
            var mc = new GameMgr();
            GameMgr.flag3 = true;
            mc.UserLogin(InputFieldManager.userName);
        }
    }
}
