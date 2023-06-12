using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI�@�\��ǂݍ���

public class TimerGUI : MonoBehaviour
{
    // === �t�B�[���h
    public Text secondText;     // "�b"��Text�R���|�[�l���g
    public Text minutesText;    // "��"��Text�R���|�[�l���g

    public float secondTimer = 0;   // �b�𑪒肷��
    public float minutesTimer = 0;  // ���𑪒肷��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondTimer += Time.deltaTime * 10;      // �����Z�Ŏ��Ԃ𑝂₷
        secondText.text = secondTimer.ToString("00");

        if (secondTimer >= 60)
        {
            minutesTimer++;     // ���� +1 ����
            minutesText.text = minutesTimer.ToString("00");

            secondTimer = 0;    // �b�����Z�b�g
        }
    }
}
