using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public BackGround bg1;
    public BackGround bg2;
    public int value = 0;
    public GameObject sawman;
    NokogiriMan sawmanCs;
    int bgChange;
    // 開始処理
    void Start()
    {
        // 初期状態設定
        bg1.setAlpha((byte)255);
        bg2.setAlpha((byte)255);
        sawmanCs = sawman.GetComponent<NokogiriMan>();
        bgChange = 31 / sawmanCs.norm;
    }

    // 更新処理
    void Update()
    {
        
         /*if (Input.GetKeyDown(KeyCode.LeftArrow))
         {
             value = value + 1;
            if (value > 31) {
                value = 31;
             }

             setValue(value);
         }*/
    }

    // 背景値を設定（0〜31指定）
    // 0 = 森100%
    // 31 = 都市100%
    public void setValue(int value) {
        float bg2Alpha = (float)value / 31 * 255;
        float bg1Alpha = 255 - bg2Alpha;

        // Debug.Log("value = " + value);
        // Debug.Log("bg1Alpha = " + bg1Alpha);
        // Debug.Log("bg2Alpha = " + bg2Alpha);

        bg1.setAlpha((byte)bg1Alpha);
        // bg2.setAlpha((byte)bg2Alpha);
    }

    //成功した際の判定
    public void SuccessBG()
    {
        value += bgChange / 2;
        if (value > 31)
        {
            value = 31;
        }
        setValue(value);
    }
    //失敗した際の判定
    public void NotSuccessBG()
    {
        value += bgChange * sawmanCs.i / 2;
        if (value > 31)
        {
            value = 31;
        }
        setValue(value);
    }
}
