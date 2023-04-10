using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // 開始処理
    void Start()
    {
    }

    // 更新処理
    void Update()
    {
    }

    // アルファ値設定：aplha（0~255）で指定
    public void setAlpha(byte alpha) {
        // 現在の色データ取得
        Renderer renderer = this.gameObject.GetComponent<Renderer>();
        Color32 color = renderer.material.color;

        // アルファ値を反映
        color.a = alpha;
        // Debug.Log (color);

        // 色データ反映
        renderer.material.color = color;
    }
}
