using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    InputField nickName;
    InputField number;
    public static bool flag4 = false;
    public static string userName;

    void Start()
    {
        nickName = GameObject.Find("Nickname").GetComponent<InputField>();
        number = GameObject.Find("Number").GetComponent<InputField>();
    }


    public void GetInputName()
    {
        userName = nickName.text + " " + number.text;
        if(2 < userName.Length &&userName.Length < 20){
            for (int i = 0; i < userName.Length; i++)
            {
                if(userName[i] == ' ')continue;

                flag4 = true;
                Debug.Log(userName);
                break;
            }
        }
        else if(15 < userName.Length)Debug.Log("名前が長すぎます！");
        else if(userName.Length < 3)Debug.Log("名前が短すぎます！");
        if(!flag4){
            Debug.Log("error");
            nickName.text = "";
            number.text = "";
        }
    }
}