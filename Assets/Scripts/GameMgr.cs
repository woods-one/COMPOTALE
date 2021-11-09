using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

/// <summary>
/// ゲームに関する処理、オブジェクトの表示非表示、ランキングなどの処理を行うスクリプト
/// </summary>
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
    GameObject scoDis;
    GameObject logMas;
    GameObject score;
    GameObject time;
    GameObject send;

    /// <summary>タップされたらいけないキャラ</summary>
    [SerializeField]
    private RealCompotale bombCharacter;

    [SerializeField]
    private List<Enemy> characters;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        nick = GameObject.Find("Nickname");
        scoDis = GameObject.Find("ScoreDisplay");
        logMas = GameObject.Find("LoginMassage");
        send = GameObject.Find("SendBotton");
        nick.SetActive(false);
        scoDis.SetActive(false);
        logMas.SetActive(false);
        send.SetActive(false);

        SetupCharacters();
    }

    /// <summary>
    /// キャラクターのセットアップ
    /// </summary>
    private void SetupCharacters()
    {
        bombCharacter.RegisterOnclickCallback(OnClickBombCharacter);

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].SetVelocityQuadrant(DirectionUtility.ConvertIntToQuadrantType(i+1));
        }
    }

    /// <summary>
    /// クリックしてはいけないキャラがクリックされた時の処理
    /// </summary>
    private void OnClickBombCharacter()
    {
        // クリックされた時の処理
        ResetCharactersVelocity();
    }

    /// <summary>
    /// 各キャラクターの移動速度のリセット
    /// </summary>
    private void ResetCharactersVelocity()
    {
        for(int i = 0; i < characters.Count; i++)
        {
            characters[i].ResetDirection();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown("return") && InputFieldManager.flag4) {
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
                scoDis.SetActive(true);
                logMas.SetActive(true);
                send.SetActive(true);
                audioSource.PlayOneShot(sound2);
                flag2 = true;
            
            }
            if(flag3 && flag5){
                ClearRoot(RealCompotale.bombCount, Enemy.Count);
                flag3 = false;
            }
        }
    }
    public static void ClearRoot(int x, int y)
    {
       if(x == 0 && y == 0)SceneManager.LoadScene("Proot");
       else if(x == 0 && 35 <= y)SceneManager.LoadScene("Troot");
       else if(0 < x && 40 <= y)SceneManager.LoadScene("Groot");
       else if(x == 0 && y < 35)SceneManager.LoadScene("Nroot");
       else if(0 < x && y < 40 && y != 0)SceneManager.LoadScene("Croot");
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
                flag3 = true;
            },
            error => 
            {
                Debug.Log("ログイン失敗");
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
                SubmitScore(Enemy.scr);
            },
            error => {
                Debug.LogError(error.GenerateErrorReport());
            }
        );
    }
}
