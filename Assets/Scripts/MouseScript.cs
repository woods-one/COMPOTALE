using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour
{

    Vector3 screenPoint;

    void Update()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        transform.position = Camera.main.ScreenToWorldPoint(a);
        if (Timer.countTime <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
