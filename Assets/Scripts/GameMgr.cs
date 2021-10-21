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
    GameObject bomb;
    GameObject aim;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnGUI()
    {        
        if(Timer.countTime <= 0)
        {
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
            ClearRoot(Bomb.bombCount, Enemy.Count);
        }
    }
    public void ClearRoot(int x, int y)
    {
       if(x == 0 && y == 1)SceneManager.LoadScene("Proot");
    }
}
