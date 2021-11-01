using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBackTitle : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Title");
        GameMgr.SubmitScore(Enemy.scr);
    }
}
