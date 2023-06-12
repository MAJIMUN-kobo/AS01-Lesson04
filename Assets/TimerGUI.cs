using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI機能を読み込む

public class TimerGUI : MonoBehaviour
{
    // === フィールド
    public Text secondText;     // "秒"のTextコンポーネント
    public Text minutesText;    // "分"のTextコンポーネント

    public float secondTimer = 0;   // 秒を測定する
    public float minutesTimer = 0;  // 分を測定する

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondTimer += Time.deltaTime * 10;      // 足し算で時間を増やす
        secondText.text = secondTimer.ToString("00");

        if (secondTimer >= 60)
        {
            minutesTimer++;     // 分を +1 する
            minutesText.text = minutesTimer.ToString("00");

            secondTimer = 0;    // 秒をリセット
        }
    }
}
