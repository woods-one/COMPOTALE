using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameMgr : MonoBehaviour
{
    public AudioClip sound2;
    public AudioClip sound3;
    AudioSource audioSource;
    bool flag2 = false;
    GameObject enemyBox;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnGUI()
    {
        if(Bomb.gameover == 1){
            if (flag2 == false)
            {           
                enemyBox = GameObject.Find("EnemyBox");
                enemyBox.SetActive(false);
                audioSource.PlayOneShot(sound3);
                flag2 = true;
            }

             // �G���S�ł���
            // �t�H���g�T�C�Y�ݒ�
            Util.SetFontSize(32);
            // ��������
            Util.SetFontAlignment(TextAnchor.MiddleCenter);
            // �t�H���g�̈ʒu
            float w = 128; // ��
            float h = 32; // ����
            float px = Screen.width / 2 - w / 2;
            float py = Screen.height / 2 - h / 2;

            // �t�H���g�`��
            Util.GUILabel(px, py, w, h, "Game Over!");
            // ����������ǉ�
            // �{�^���͏������ɂ��炷
            py += 60;
            if (GUI.Button(new Rect(px, py, w, h), "Back to Title"))
            {
                // �^�C�g����ʂɂ��ǂ�
                SceneManager.LoadScene("Title");
            }
        }
        
        if(Enemy.Count == 0)
        {
            if (flag2 == false)
            {
                enemyBox = GameObject.Find("Bomb");
                enemyBox.SetActive(false);
                audioSource.PlayOneShot(sound2);
                flag2 = true;
            }
            // �G���S�ł���
            // �t�H���g�T�C�Y�ݒ�
            Util.SetFontSize(32);
            // ��������
            Util.SetFontAlignment(TextAnchor.MiddleCenter);
            // �t�H���g�̈ʒu
            float w = 128; // ��
            float h = 32; // ����
            float px = Screen.width / 2 - w / 2;
            float py = Screen.height / 2 - h / 2;

            // �t�H���g�`��
            Util.GUILabel(px, py, w, h, "Game Clear!");
            // ����������ǉ�
            // �{�^���͏������ɂ��炷
            py += 60;
            if (GUI.Button(new Rect(px, py, w, h), "Back to Title"))
            {
                // �^�C�g����ʂɂ��ǂ�
                SceneManager.LoadScene("Title");
            }
        }
    }
}
