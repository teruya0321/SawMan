using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public AudioSource pushStartSE;

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
            pushStartSE.Play();

            Invoke("changeScene", 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
        }
    }

    // シーン遷移処理
    private void changeScene() {
        SceneManager.LoadScene("Rule");
    }
}
