using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float countTime;

    void Start()
    {
        countTime = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // countTimeに、ゲームが開始してからの秒数を格納
        countTime -= Time.deltaTime;
        if(countTime <= 0)countTime = 0;
        // 小数2桁にして表示
        GetComponent<Text>().text = "Time: " + countTime.ToString("F2");
    }
}