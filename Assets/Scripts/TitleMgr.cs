using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class TitleMgr : MonoBehaviour
{
    void OnGUI()
    {
        // �t�H���g�T�C�Yが
        Util.SetFontSize(50);
        // ��������
        Util.SetFontAlignment(TextAnchor.MiddleCenter);

        // �t�H���g�̈ʒu
        float w = 128; // ��
        float h = 32; // ����
        float px = Screen.width / 2 - w / 2;
        float py = Screen.height / 2 - h / 2;

        // �t�H���g�`��
        Util.GUILabel(px, py, w, h, "COMPOTALE!!!");

        // �{�^���͏������ɂ��炷
        py += 60;
        if (GUI.Button(new Rect(px, py, w, h), "START"))
        {
            Enemy.Count = 0;
            // ���C���Q�[���J�n
            SceneManager.LoadScene ("Main");
        }
    }
}
