using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ランキングのニックネームを入力する処理
/// </summary>

public class InputFieldManager : MonoBehaviour
{
    InputField nickName;
    public static bool flag4 = false;
    public static string userName;

    void Start()
    {
        nickName = GameObject.Find("Nickname").GetComponent<InputField>();
    }


    public void GetInputName()
    {
        userName = nickName.text;
        if(2 < userName.Length &&userName.Length < 16){
            for (int i = 0; i < userName.Length; i++)
            {
                if(userName[i] == ' ')continue;

                flag4 = true;
                break;
            }
        }
        if(!flag4){
            nickName.text = "";
        }
    }
}