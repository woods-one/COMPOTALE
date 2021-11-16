using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ランキングを表示するスクリプト
/// </summary>

public class ShowRanking : MonoBehaviour {

  [SerializeField]
  private Text rankingText = default;

  void Start()
  {
    RankingUserLogin();
  }

  public void GetLeaderboard() { 
    var request = new GetLeaderboardRequest{
      StatisticName   = "COMPTALERanking",
      StartPosition   = 0,
      MaxResultsCount = 10
    };

    Debug.Log($"ランキング(リーダーボード)の取得開始");
    PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboardSuccess, OnGetLeaderboardFailure);
  }
  
  private void OnGetLeaderboardSuccess(GetLeaderboardResult result){
    Debug.Log($"ランキング(リーダーボード)の取得に成功しました");

    rankingText.text = "";
    foreach (var entry in result.Leaderboard) {
      rankingText.text += $"順位 : {entry.Position + 1}位  スコア : {entry.StatValue}  名前 : {entry.DisplayName}\n\n";
    }
  }

  private void OnGetLeaderboardFailure(PlayFabError error){
    Debug.LogError($"ランキング(リーダーボード)の取得に失敗しました\n{error.GenerateErrorReport()}");
    rankingText.text += "ランキングの取得に失敗しました\nタイトルに戻って再度お試しください";
  }
  public void RankingUserLogin()
  {
      PlayFabClientAPI.LoginWithCustomID(
        new LoginWithCustomIDRequest { CustomId = "ranker", CreateAccount = true},
          result => 
          {
            Debug.Log("ログイン成功！");
            GetLeaderboard();
          },
          error => 
          {
            Debug.Log("ログイン失敗");
          }
      );
  }
}