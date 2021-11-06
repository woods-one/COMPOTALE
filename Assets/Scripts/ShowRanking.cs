using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class ShowRanking : MonoBehaviour {

  public Text _rankingText = default;

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

    _rankingText.text = "";
    foreach (var entry in result.Leaderboard) {
      _rankingText.text += $"順位 : {entry.Position + 1}, スコア : {entry.StatValue}, 名前 : {entry.DisplayName}\n";
    }
  }

  private void OnGetLeaderboardFailure(PlayFabError error){
    Debug.LogError($"ランキング(リーダーボード)の取得に失敗しました\n{error.GenerateErrorReport()}");
  }
    public void RankingUserLogin()
    {
        PlayFabClientAPI.LoginWithCustomID(
        new LoginWithCustomIDRequest { CustomId = "ranker", CreateAccount = true},
            result => 
            {
                
                Debug.Log("ログイン成功！");
            },
            error => 
            {
                Debug.Log("ログイン失敗");
            }
        );
    }
}