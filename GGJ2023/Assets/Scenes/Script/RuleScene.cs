using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleScene : MonoBehaviour
{
    // 開始
    void Start()
    {
    }

    // 更新
    void Update()
    {
        // スペースキーが押されたらSE再生
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
