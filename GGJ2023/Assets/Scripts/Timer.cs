using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public Text timerText;
    public delegate void OnTimeupDelegate();
    public OnTimeupDelegate onTimeupDelegate;
	float initialTime;
    bool active = false;
	int seconds;

	// 開始
	void Start () {
	}

	// 更新
	void Update () {
        // アクティブでない場合は何もしない
        if (!active) {
            return;
        }

        // カウントダウン
        initialTime -= Time.deltaTime;
        seconds = (int)initialTime;

        // テキストに反映
        string text = "残り時間：" + seconds.ToString() + "秒";
		timerText.text = text;
        // Debug.Log (text);
        
        // タイマー終了
        if (seconds == 0) {
            timerStop();

            // 通知
            onTimeupDelegate?.Invoke();
        }
	}

    // 時間設定
    public void set(int time) {
        initialTime = (float)time;
    }

    // タイマー開始
    public void timerStart() {
        active = true;
    }

    // タイマー停止
    public void timerStop() {
        active = false;
    }
}
