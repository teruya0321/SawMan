using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NormClearEnd : MonoBehaviour
{
    public AudioSource se1;
    public Text resultText;
    int result;
    // 開始
    void Start()
    {
        result = NokogiriMan.getScore();
        resultText.text = result.ToString();
        Invoke("playSe1", 1.0f);
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

    // SE1再生
    private void playSe1() {
        se1.Play();
    }
}
