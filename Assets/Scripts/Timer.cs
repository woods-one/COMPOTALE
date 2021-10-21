using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float countTime;

    void Start()
    {
        countTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        countTime -= Time.deltaTime;
        if(countTime <= 0)countTime = 0;
        // 小数2桁にして表示
        GetComponent<Text>().text = "Time: " + countTime.ToString("F2");
    }
}