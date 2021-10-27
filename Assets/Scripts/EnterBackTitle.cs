using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBackTitle : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown("return")) {
            SceneManager.LoadScene("Title");
            GameMgr.SubmitScore(Enemy.scr);
        }
    }
}
