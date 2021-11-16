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
    [SerializeField]
    private AudioClip soundGameClear;
    AudioSource audioSource;
    bool isCountZero = false;
    GameObject clearGameUI;
    GameObject playingGameUI;
    GameObject playingGameObject;

    /// <summary>タップされたらいけないキャラ</summary>
    [SerializeField]
    private RealCompota realCompotaCharacter;

    [SerializeField]
    private List<Enemy> characters;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clearGameUI = GameObject.Find("ClearGameUI");
        clearGameUI.SetActive(false);

        SetupCharacters();
    }

    /// <summary>
    /// キャラクターのセットアップ
    /// </summary>
    private void SetupCharacters()
    {
        realCompotaCharacter.RegisterOnclickCallback(OnClickRealCompotaCharacter);

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].SetVelocityQuadrant(DirectionUtility.ConvertIntToQuadrantType(i+1));
        }
    }

    /// <summary>
    /// クリックしてはいけないキャラがクリックされた時の処理
    /// </summary>
    private void OnClickRealCompotaCharacter()
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

    public void Update()
    {        
        if(Timer.countTime <= 0)
        {
            if (!isCountZero)
            {
                playingGameUI = GameObject.Find("PlayingGameUI");
                playingGameObject = GameObject.Find("PlayingGameObject");
                playingGameUI.SetActive(false);
                playingGameObject.SetActive(false);
                clearGameUI.SetActive(true);
                audioSource.PlayOneShot(soundGameClear);
                isCountZero = true;

            }
        }
    }
    public void ClearRoot(int x, int y)
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
                SubmitScore(Enemy.score);
            },
            error => {
                Debug.LogError(error.GenerateErrorReport());
            }
        );
    }
}
