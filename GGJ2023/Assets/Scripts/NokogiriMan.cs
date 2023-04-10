using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NokogiriMan : MonoBehaviour
{
    public GameObject canvas;
    MainScene mainsceneCs;

    //public Animator animator;  // アニメーターコンポーネント取得用
    public Image sliderimage;
    public Slider slider;

    //現在のゲージ量
    float nowGauge;

    //ゲージの最大値
    float maxGauge;

    //ゲージの最小値
    float minGauge;

    //ゲージを上下するための判定
    bool maxfloat;

    //ゲージの成功判定の上限
    float randomfloatmin;
    //ゲージの成功判定の下限
    float randomfloatmax;

    //ゲージが今動かせるかの判定
    bool gauge = true;

    //ゲージの動くスピード
    float gaugespeed;

    //キャラを動かすための指定
    Vector3 pos;

    //キャラのアニメーター
    public Animator sawmanAnim;
    //キャラのアニメーション終了の判定を取るためのタイマー
    float movetimer;

    //動ける状態かそうでないかの判定
    bool moving = true;

    //のこぎりマンのライフ
    public int sawLife;

    public GUIStyle textStyle;

    public int norm;

    public int cutTree;

    public static int cutScore;

    public GameObject bg;

    BackGroundManager bgmana;

    public int i;

    public AudioSource oneCutTree;

    public AudioSource manyCutTree;

    public AudioSource missCutTree;

    public AudioSource clickGauge;

    public AudioSource run;

    public Life life;

    public GameObject wood;

    Wood woodCs;

    public Text normText;
    // Start is called before the first frame update
    private void OnGUI()
    {
        //GUI.Label(new Rect(500, 100, 50, 50), "今回のノルマ:" + norm, textStyle);
    }
    void Start()
    {
        //現在のゲージ量
        nowGauge = 0;
        //ゲージの最大値
        maxGauge = 100;
        //ゲージの最小値
        minGauge = 0;
        //最大値、最小値の設定
        slider.maxValue = maxGauge;
        slider.minValue = minGauge;
        //ゲージの成功する範囲を指定
        randomfloatmin = Random.Range(30, 50);
        randomfloatmax = Random.Range(60, 80);
        pos.z = -4;
        sawLife = 3;
        gaugespeed = Random.Range(3.0f, 4.0f);
        norm = Random.Range(5, 16);
        mainsceneCs = canvas.GetComponent<MainScene>();
        bgmana = bg.GetComponent<BackGroundManager>();
        woodCs = wood.GetComponent<Wood>();
        run.Play();
        cutScore = 0;
        normText.text = "今回のノルマ：" + norm.ToString() + "本";
    }

    // Update is called once per frame
    void Update()
    {
        cutScore = cutTree;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale != 0) {
                Time.timeScale = 0;
                gaugespeed = 0;
            }
            else {
                Time.timeScale = 1;
                gaugespeed = Random.Range(3.0f, 4.0f);
            }
        }
        if(Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            mainsceneCs.onTimeup();
        }
        //走っている状態ならば
        if (moving)
        {
            //移動を指定
            pos.x += Time.deltaTime * 10;
            //走るアニメーション
            sawmanAnim.SetBool("Run", true);
            //木のあるところまでたどり着いたら
            if (pos.x >= 50)
            {
                //動きを止める
                moving = false;
                run.Stop();
                //ゲージが押されてなかったら
                if (gauge)
                {
                    //強制的に0で固定させる
                    nowGauge = 0;
                    gauge = false;
                }
                //成功判定
                if (nowGauge >= randomfloatmin && nowGauge <= randomfloatmax)
                {
                    Debug.Log("成功");
                    sawmanAnim.SetTrigger("Success");
                    cutTree++;
                    bgmana.Invoke("SuccessBG",1.6f);
                    Invoke("OneCutTree", 0.8f);
                    woodCs.Invoke("CutWood", 1.0f);
                }
                //失敗判定、ライフを一つ失う
                else if (nowGauge < randomfloatmin)
                {
                    Debug.Log("失敗");
                    sawmanAnim.SetTrigger("Miss");
                    sawLife--;
                    life.setValue(sawLife);
                    Invoke("MissCutTree", 0.1f);
                }
                //切りすぎの判定
                else if (nowGauge > randomfloatmax)
                {
                    Debug.Log("切りすぎ");
                    sawmanAnim.SetTrigger("NotSuccess");
                    i = Random.Range(2, 5);
                    cutTree += i;
                    bgmana.Invoke("NotSuccessBG", 1.6f);
                    Invoke("ManyCutTree", 0.5f);
                    woodCs.Invoke("CutWood", 0.8f);
                }
            }
        }
        else
        {
            //sawmanAnim.SetBool("Run", false);
            //動き始めるまでの秒数(アニメーションが基準)
            movetimer += Time.deltaTime;
            //何秒か経ったら(切るアニメーションが終わったら)
            if (movetimer >= 1.6)
            {
                //走れるようにする
                moving = true;
                //別の関数を少し遅れて呼び出し
                Invoke("GaugeReset", 0.1f);
                //木との距離をランダムにするため適当な範囲に移動
                pos.x = Random.Range(-40, 30);
                //タイマーをリセット
                movetimer = 0;
            }
        }
        //ゲージの値を取得
        transform.position = pos;
        slider.value = nowGauge;
        //ゲージが動かせる状態ならば
        if (gauge)
        {
            if (Time.timeScale != 0 && Input.GetKeyDown(KeyCode.Space))
            {
                gauge = false;
                clickGauge.Play();
            }
        }
    }
    private void FixedUpdate()
    {
        if (gauge)
        {
            if (!maxfloat)
            {
                //ゲージの上昇
                nowGauge += gaugespeed;
            }
            else
            {
                //ゲージの下降
                nowGauge -= gaugespeed;
            }
            if (nowGauge >= maxGauge)
            {
                //ゲージが上限まで達したら下がるように
                maxfloat = true;
                gaugespeed = Random.Range(3.0f, 4.0f);
            }
            else if (nowGauge <= minGauge)
            {
                //ゲージが下限まで達したら上がるように
                maxfloat = false;
                gaugespeed = Random.Range(1.0f, 2.0f);
            }
            if (nowGauge >= randomfloatmin && nowGauge <= randomfloatmax)
            {
                //Debug.Log("成功");
                //成功の判定
                sliderimage.color = new Color(0, 1, 0, 1);
            }
            else if (nowGauge < randomfloatmin)
            {
                //失敗の判定
                sliderimage.color = new Color(1, 0, 0, 1);

            }
            else if (nowGauge > randomfloatmax)
            {
                //切りすぎの判定
                sliderimage.color = new Color(0, 1, 1, 1);
            }
            
        }
    }
    //ゲージリセット用の関数
    void GaugeReset()
    {
        //新たにゲージの成功範囲を指定
        randomfloatmin = Random.Range(30, 50);
        randomfloatmax = Random.Range(60, 80);
        
        //現在のゲージ量を0に戻す
        nowGauge = 0;
        //ゲージを動かせるようにする
        gauge = true;
        manyCutTree.Stop();
        missCutTree.Stop();
        run.Play();

        if(sawLife <= 0)
        {
            mainsceneCs.BreakSawEndScene();
        }
    }

    public static int getScore()
    {
        return cutScore;
    }
    void OneCutTree()
    {
        oneCutTree.Play();
    }
    void ManyCutTree()
    {
        manyCutTree.Play();
    }
    void MissCutTree()
    {
        missCutTree.Play();
    }
}
