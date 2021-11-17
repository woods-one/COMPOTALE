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
    public static bool isNotUserNameNull = false;
    public static string userName;

    public void GetInputName()
    {
        nickName = GameObject.Find("NickName").GetComponent<InputField>();
        userName = nickName.text;
        if(2 < userName.Length &&userName.Length < 16){
            for (int i = 0; i < userName.Length; i++)
            {
                if(userName[i] == ' ' || userName[i] == '　')continue;

                isNotUserNameNull = true;
                break;
            }
        }
        if(!isNotUserNameNull){
            nickName.text = "";
        }
    }
}