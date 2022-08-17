using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// カウントダウンするタイマーのスクリプト
/// </summary>
public class Timer : MonoBehaviour
{
    public static float countTime;

    [SerializeField]
    private Text timerText;

    void Start()
    {
        countTime = 60;
    }

    void Update()
    {
        countTime -= Time.deltaTime;
        if(countTime <= 0)countTime = 0;
        timerText.text = $"Time: {countTime:F2}";
    }
}