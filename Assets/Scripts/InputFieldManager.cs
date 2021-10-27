using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    InputField inputField;
    public static bool flag4 = false;
    public static string userName;

    void Start()
    {
        inputField = GameObject.Find("InputField").GetComponent<InputField>();
    }

    public void GetInputName()
    {
        userName = inputField.text;
        if(userName.Length < 16){
            for (int i = 0; i < userName.Length; i++)
            {
                if(userName[i] == ' ')continue;

                flag4 = true;
                Debug.Log(userName);
                break;
            }
        }
        else Debug.Log("名前が長すぎます！");
        if(!flag4)Debug.Log("error");
        inputField.text = "";
    }
}