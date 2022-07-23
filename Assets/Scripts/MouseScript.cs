using UnityEngine;
using System.Collections;

/// <summary>
/// オブジェクトがマウスを追いかけるスクリプト
/// </summary>
public class MouseScript : MonoBehaviour
{
    private Vector3 position;
    
    void FixedUpdate () {
        // Vector3でマウス位置座標を取得する
        position = Input.mousePosition;
        // Z軸修正
        position.z = 10f;
        
        // ワールド座標に変換されたマウス座標を代入
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(position);
    }
}
