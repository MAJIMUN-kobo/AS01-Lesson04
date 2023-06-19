using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI機能を読み込む

public class TimerGUI : MonoBehaviour
{
    // === フィールド
    public Text secondText;     // "秒"のTextコンポーネント
    public Text minutesText;    // "分"のTextコンポーネント
    public Text hourText;       // "時"のTextコンポーネント
    public Text conmaText;      // 小数点以下のTextコンポーネント
    

    public float secondTimer = 0;   // 秒を測定する
    public float minutesTimer = 0;  // 分を測定する
    public float hourTimer = 0;     // 時を測定する

    public bool isStart = false;    // スタートしているか？のフラグ

    #region おまけ
    public Button startAndStopButton = null;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        #region おまけ
        startAndStopButton.onClick.AddListener(() => { OnStartAndStopClicked(); });
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            secondTimer += Time.deltaTime * 1;      // 足し算で時間を増やす
            secondText.text = secondTimer.ToString("00");
            conmaText.text = (secondTimer - Mathf.Floor(secondTimer)).ToString(".00");

            // === 60秒たったら1分増やす
            if (secondTimer >= 60)
            {
                minutesTimer++;     // 分を +1 する
                minutesText.text = minutesTimer.ToString("00");

                secondTimer = 0;    // 秒をリセット
                secondText.text = secondTimer.ToString("00");
            }

            // === 60分たったら1時間増やす
            if (minutesTimer >= 60)
            {
                hourTimer++;        // 時を +1 する
                hourText.text = hourTimer.ToString("00");

                minutesTimer = 0;   // 分をリセット
                minutesText.text = minutesTimer.ToString("00");
            }
        }
    }

    // === "スタートボタンを押したときの処理"に登録する関数
    public void OnStartClicked()
    {
        Debug.Log("スタートボタンが押されました。");

        // タイマーのフラグを切り替える
        isStart = true;                 // Trueにして動かす
    }

    // === "ストップボタンを押したときの処理"に登録する関数
    public void OnStopClicked()
    {
        Debug.Log("ストップボタンが押されました。");

        // タイマーのフラグを切り替える
        isStart = false;                // Falseにして止める
    }

    // === "リセットボタンを押したときの処理"に登録する関数
    public void OnResetClicked()
    {
        Debug.Log("リセットボタンが押されました。");

        // タイマーの内部数値をリセット
        secondTimer = 0;
        minutesTimer = 0;
        hourTimer = 0;

        // タイマーの表示を更新
        secondText.text = secondTimer.ToString("00");
        minutesText.text = minutesTimer.ToString("00");
        hourText.text = hourTimer.ToString("00");
        conmaText.text = secondTimer.ToString(".00");
    }

    // === 終了ボタンを押したときの処理に登録する関数
    public void OnExitApplicationClicked()
    {
        Application.Quit();     // アプリを終了させる
    }

    #region おまけ
    public void OnStartAndStopClicked()
    {
        isStart = !isStart;
    }
    #endregion
}
