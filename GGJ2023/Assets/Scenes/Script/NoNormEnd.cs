using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NoNormEnd : MonoBehaviour
{
    public AudioSource se1;
    public AudioSource se2;
    public Text resultText;
    int result;
    // 開始
    void Start()
    {
        result = NokogiriMan.getScore();
        resultText.text = result.ToString();
        Invoke("playSe1", 2.0f);
        Invoke("playSe2", 6.0f);
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

    // SE2再生
    private void playSe2() {
        se2.Play();
    }
}
