using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI�@�\��ǂݍ���

public class TimerGUI : MonoBehaviour
{
    // === �t�B�[���h
    public Text secondText;     // "�b"��Text�R���|�[�l���g
    public Text minutesText;    // "��"��Text�R���|�[�l���g
    public Text hourText;       // "��"��Text�R���|�[�l���g
    public Text conmaText;      // �����_�ȉ���Text�R���|�[�l���g
    

    public float secondTimer = 0;   // �b�𑪒肷��
    public float minutesTimer = 0;  // ���𑪒肷��
    public float hourTimer = 0;     // ���𑪒肷��

    public bool isStart = false;    // �X�^�[�g���Ă��邩�H�̃t���O

    #region ���܂�
    public Button startAndStopButton = null;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        #region ���܂�
        startAndStopButton.onClick.AddListener(() => { OnStartAndStopClicked(); });
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            secondTimer += Time.deltaTime * 1;      // �����Z�Ŏ��Ԃ𑝂₷
            secondText.text = secondTimer.ToString("00");
            conmaText.text = (secondTimer - Mathf.Floor(secondTimer)).ToString(".00");

            // === 60�b��������1�����₷
            if (secondTimer >= 60)
            {
                minutesTimer++;     // ���� +1 ����
                minutesText.text = minutesTimer.ToString("00");

                secondTimer = 0;    // �b�����Z�b�g
                secondText.text = secondTimer.ToString("00");
            }

            // === 60����������1���ԑ��₷
            if (minutesTimer >= 60)
            {
                hourTimer++;        // ���� +1 ����
                hourText.text = hourTimer.ToString("00");

                minutesTimer = 0;   // �������Z�b�g
                minutesText.text = minutesTimer.ToString("00");
            }
        }
    }

    // === "�X�^�[�g�{�^�����������Ƃ��̏���"�ɓo�^����֐�
    public void OnStartClicked()
    {
        Debug.Log("�X�^�[�g�{�^����������܂����B");

        // �^�C�}�[�̃t���O��؂�ւ���
        isStart = true;                 // True�ɂ��ē�����
    }

    // === "�X�g�b�v�{�^�����������Ƃ��̏���"�ɓo�^����֐�
    public void OnStopClicked()
    {
        Debug.Log("�X�g�b�v�{�^����������܂����B");

        // �^�C�}�[�̃t���O��؂�ւ���
        isStart = false;                // False�ɂ��Ď~�߂�
    }

    // === "���Z�b�g�{�^�����������Ƃ��̏���"�ɓo�^����֐�
    public void OnResetClicked()
    {
        Debug.Log("���Z�b�g�{�^����������܂����B");

        // �^�C�}�[�̓������l�����Z�b�g
        secondTimer = 0;
        minutesTimer = 0;
        hourTimer = 0;

        // �^�C�}�[�̕\�����X�V
        secondText.text = secondTimer.ToString("00");
        minutesText.text = minutesTimer.ToString("00");
        hourText.text = hourTimer.ToString("00");
        conmaText.text = secondTimer.ToString(".00");
    }

    // === �I���{�^�����������Ƃ��̏����ɓo�^����֐�
    public void OnExitApplicationClicked()
    {
        Application.Quit();     // �A�v�����I��������
    }

    #region ���܂�
    public void OnStartAndStopClicked()
    {
        isStart = !isStart;
    }
    #endregion
}
