using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration         = 1f; //f�t�F�[�h���������鎞��
    public float displayImageDuration = 1f;

    public GameObject player; //�Q��
    public CanvasGroup exitBackgroundImageCanvasGroup;

    bool m_IsPlayerAtExit; //�t�F�[�h�C�����J�n���邩�ǂ���
    float m_Timer; //�^�C�}�[�A�t�F�[�h����O�ɃQ�[�����I�����Ȃ��悤��

    /// <summary>
    /// �����蔻��i�������I�j
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)//�������Q�[���I�u�W�F�N�g���v���C���[��������
        {
            m_IsPlayerAtExit = true;//�t�F�[�h�J�n
        }
    }

    void Update()
    {
        if (m_IsPlayerAtExit)//�t�F�[�h�J�n
        {
            EndLevel();
        } 
    }

    /// <summary>
    /// Canvas Group���t�F�[�h���Ă���A�Q�[�����I������
    /// </summary>
    void EndLevel()
    {
        m_Timer += Time.deltaTime; //�^�C�}�[�̃J�E���g�A�b�v

        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;//CanvasGround.alfa��UI�̓��߂��X�N���v�g����܂Ƃ߂Ē���

        if (m_Timer > fadeDuration + displayImageDuration)//�^�C�}�[���������Ԃ������
        {
            Application.Quit();//�I��
        }
    }

}
