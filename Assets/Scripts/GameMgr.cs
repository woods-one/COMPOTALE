using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class GameMgr : MonoBehaviour
{
    public AudioClip sound2;
    public AudioClip sound3;
    AudioSource audioSource;
    bool flag2 = false;
    public static bool flag3 = false;
    public static bool flag5 = false;
    GameObject enemyBox;
    GameObject bomb;
    GameObject aim;
    GameObject nick;
    GameObject num;
    GameObject scoDis;
    GameObject logMas;
    GameObject score;
    GameObject time;
    GameObject butMgr;
    public GUISkin guiSkin; 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        nick = GameObject.Find("Nickname");
        num = GameObject.Find("Number");
        scoDis = GameObject.Find("ScoreDisplay");
        logMas = GameObject.Find("LoginMassage");
        butMgr = GameObject.Find("ButtonMgr");
        nick.SetActive(false);
        num.SetActive(false);
        scoDis.SetActive(false);
        logMas.SetActive(false);
        butMgr.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown("return") && InputFieldManager.flag4) {
            flag3 = true;
            UserLogin(InputFieldManager.userName);
        }
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
                score = GameObject.Find("Score");
                time = GameObject.Find("Time");
                enemyBox.SetActive(false);
                bomb.SetActive(false);
                aim.SetActive(false);
                score.SetActive(false);
                time.SetActive(false);
                nick.SetActive(true);
                num.SetActive(true);
                scoDis.SetActive(true);
                logMas.SetActive(true);
                butMgr.SetActive(true);
                audioSource.PlayOneShot(sound2);
                flag2 = true;
            
            }
            if(flag3 && flag5){
                ClearRoot(Bomb.bombCount, Enemy.Count);
                flag3 = false;
            }
        }
    }
    public static void ClearRoot(int x, int y)
    {
       if(x == 0 && y == 0)SceneManager.LoadScene("Proot");
       else if(x == 0 && 35 <= y)SceneManager.LoadScene("Troot");
       else if(0 < x && 50 <= y)SceneManager.LoadScene("Groot");
       else if(x == 0 && y < 35)SceneManager.LoadScene("Nroot");
       else if(0 < x && y < 50)SceneManager.LoadScene("Croot");
       else if(0 < x && y == 0)SceneManager.LoadScene("Broot");
    }
    public void UserLogin(string usename)
    {
        PlayFabClientAPI.LoginWithCustomID(
        new LoginWithCustomIDRequest { CustomId = usename, CreateAccount = true},
            result => 
            {
                Debug.Log("ログイン成功！");
                SetPlayerDisplayName(usename);
                flag5 = true;
            },
            error => 
            {
                Debug.Log("ログイン失敗");
                UserLogin(InputFieldManager.userName);
            }
        );
    }
    public static void SubmitScore(int score)
    {
        PlayFabClientAPI.UpdatePlayerStatistics(
            new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>()
                {
                    new StatisticUpdate
                    {
                        StatisticName = "COMPTALERanking",
                        Value = score
                    }
                }
            },
            result =>
            {
                Debug.Log("スコア送信");
            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
            }
        );
    }
    void SetPlayerDisplayName (string displayName) 
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(
            new UpdateUserTitleDisplayNameRequest {
                DisplayName = displayName
            },
            result => {
                Debug.Log("Set display name was succeeded");
            },
            error => {
                Debug.LogError(error.GenerateErrorReport());
            }
        );
    }
}
