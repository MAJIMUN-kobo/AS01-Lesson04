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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondTimer += Time.deltaTime *1;      // 足し算で時間を増やす
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

    // === "ボタン押したときの処理"に登録する関数
    public void OnStartClicked()
    {
        Debug.Log("スタートボタンが押されました。");
    }

    public void OnStopClicked()
    {
        Debug.Log("ストップボタンが押されました。");
    }
}
