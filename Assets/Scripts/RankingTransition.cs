using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingTransition : MonoBehaviour
{
    public void OnMouseDown()
    {
       SceneManager.LoadScene("Ranking");
    }
}
