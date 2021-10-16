using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountText : MonoBehaviour
{
    public Text score;
    
 
    void Update()
    {
        score.text = "SCORE: " + Enemy.scr.ToString();
    }
}