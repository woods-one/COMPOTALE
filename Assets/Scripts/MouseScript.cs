using UnityEngine;
using System.Collections;

/// <summary>
/// オブジェクトがマウスを追いかけるスクリプト
/// </summary>

public class MouseScript : MonoBehaviour
{

    Vector3 screenPoint;

    void Update()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mouseCoordinate = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        transform.position = Camera.main.ScreenToWorldPoint(mouseCoordinate);
        if (Timer.countTime <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
