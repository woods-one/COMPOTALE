using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameMgr : MonoBehaviour
{
    public AudioClip sound2;
    public AudioClip sound3;
    AudioSource audioSource;
    bool flag2 = false;
    bool flag3 = false;
    GameObject enemyBox;
    GameObject bomb;
    GameObject aim;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetKeyDown("return")) {
            flag3 = true;
        }
    }
    public void OnGUI()
    {        
        if(Timer.countTime <= 0)
        {
            Util.SetFontSize(50);
            Util.SetFontAlignment(TextAnchor.MiddleCenter);
            float w = 128;
            float h = 32; 
            float px = Screen.width / 2 - w / 2;
            float py = Screen.height / 2 - h / 2;
            Util.GUILabel(px, py, w, h, "Please Press Enter");

            if (!flag2)
            {
                enemyBox = GameObject.Find("EnemyBox");
                bomb = GameObject.Find("Bomb");
                aim = GameObject.Find("Aim");
                enemyBox.SetActive(false);
                bomb.SetActive(false);
                aim.SetActive(false);
                audioSource.PlayOneShot(sound2);
                flag2 = true;
            }
            if(flag3){
                ClearRoot(Bomb.bombCount, Enemy.Count);
                flag3 = false;
            }
        }
    }
    public void ClearRoot(int x, int y)
    {
       if(x == 0 && y == 0)SceneManager.LoadScene("Proot");
       else if(x == 0 && 30 <= y)SceneManager.LoadScene("Troot");
       else if(0 < x && 30 <= y)SceneManager.LoadScene("Groot");
       else if(x == 0 && y < 30)SceneManager.LoadScene("Nroot");
       else if(0 < x && y < 30)SceneManager.LoadScene("Croot");
       else if(0 < x && y == 0)SceneManager.LoadScene("Broot");
    }
}
