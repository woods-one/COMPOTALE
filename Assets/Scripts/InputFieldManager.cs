using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// ランキングのニックネームを入力する処理
/// </summary>
public class InputFieldManager : MonoBehaviour
{
    [SerializeField]
    InputField nickName;
    
    public bool isNotUserNameNull = false;
    public string userName;

    public void GetInputName()
    {
        userName = nickName.text;
        if(2 < userName.Length && userName.Length < 16){
            if (!String.IsNullOrWhiteSpace(userName))
            {
                isNotUserNameNull = true;
            }
        }
        if(!isNotUserNameNull){
            nickName.text = "";
        }
    }
}