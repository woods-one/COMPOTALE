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
    bool flag3 = false;
    GameObject enemyBox;
    GameObject bomb;
    GameObject aim;
    GameObject inputer;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        inputer = GameObject.Find("InputField");
        inputer.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown("return") && InputFieldManager.flag4) {
            flag3 = true;
            PlayFabClientAPI.LoginWithCustomID(
            new LoginWithCustomIDRequest { CustomId = InputFieldManager.userName, CreateAccount = true},
            result => 
            {
                Debug.Log("ログイン成功！");
                SetPlayerDisplayName(InputFieldManager.userName);
            },
            error => Debug.Log("ログイン失敗"));
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
            Util.GUILabel(px, py, w, h, "あなたのスコアは" + Enemy.scr.ToString() + "点です！");
            Util.SetFontSize(25);
            Util.GUILabel(px, py + 45, w, h, "ニックネームを入力してランキングに登録しよう！");

            if (!flag2)
            {
                enemyBox = GameObject.Find("EnemyBox");
                bomb = GameObject.Find("Bomb");
                aim = GameObject.Find("Aim");
                enemyBox.SetActive(false);
                bomb.SetActive(false);
                aim.SetActive(false);
                inputer.SetActive(true);
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
