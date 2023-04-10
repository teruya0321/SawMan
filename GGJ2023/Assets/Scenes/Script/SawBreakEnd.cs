using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SawBreakEnd : MonoBehaviour
{
    // 開始
    void Start()
    {
    }

    // 更新
    void Update()
    {
        // スペースキーが押されたらシーン遷移
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Title2");
        }
    }
}
