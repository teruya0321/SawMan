using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public Timer timer;
    GameObject sawman;
    NokogiriMan sawmanscript;
    // 開始処理
    void Start()
    {
        // タイムアップの通知設定
        timer.onTimeupDelegate = onTimeup;

        // 制限時間を決める
        System.Random rnd = new System.Random();
        int time = rnd.Next(60, 60);//5から10（仮）

        // タイマー時間を設定
        timer.set(time);
        // タイマー開始
        timer.timerStart();

        sawman = GameObject.Find("SawMan");
        sawmanscript = sawman.GetComponent<NokogiriMan>();
    }

    // 更新処理
    void Update()
    {
    }

    // ゲーム終了
    public void onTimeup() {
        //Debug.Log ("time up");
        //切った数がノルマと同じならNormClearEndに飛ばす
        if(sawmanscript.cutTree == sawmanscript.norm)
        {
            HappyEndScene();
        }
        //切った数がノルマより少ないならNoNormEndに飛ばす
        else if(sawmanscript.cutTree < sawmanscript.norm)
        {
            NoNormEndScene();
        }
        //切った数がノルマより多く、ノルマの二倍の数より少ないならNormOverEndに飛ばす
        else if(sawmanscript.cutTree > sawmanscript.norm && sawmanscript.cutTree < sawmanscript.norm * 2)
        {
            NormOverEndScene();
        }
        //切った数がノルマの二倍以上ならBadEndに飛ばす
        if(sawmanscript.cutTree > sawmanscript.norm * 2)
        {
            BadEndScene();
        }
    }

    public void BadEndScene()
    {
        SceneManager.LoadScene("BadEndScene");
    }

    public void NormOverEndScene()
    {
        SceneManager.LoadScene("NormOverEnd");
    }

    public void HappyEndScene()
    {
        SceneManager.LoadScene("NormClearEnd");
    }

    public void NoNormEndScene()
    {
        SceneManager.LoadScene("NoNormEnd");
    }

    public void BreakSawEndScene()
    {
        SceneManager.LoadScene("SawBreakEnd");
    }
}
