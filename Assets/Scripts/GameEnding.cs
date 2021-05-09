using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration         = 1f;              //f�t�F�[�h���������鎞��
    public float displayImageDuration = 1f;
    public GameObject player;                            // �Q��
    public CanvasGroup exitBackgroundImageCanvasGroup;   // �v���C���[���E�o�����ꍇ�ɕ\�������摜�p
    public CanvasGroup caugthBackgroundImageCanvasGroup; // �v���C���[���L���b�`���ꂽ�ꍇ�ɕ\�������V�����摜�p

    bool m_IsPlayerAtExit; //�o���ɓ��B�������ǂ���
    bool m_IsPlayerCaught; //�L���b�`���ꂽ���ǂ���
    float m_Timer;         //�^�C�}�[�A�t�F�[�h����O�ɃQ�[�����I�����Ȃ��悤��

    /// <summary>
    /// �����蔻��i�������I�j
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) // �������Q�[���I�u�W�F�N�g���v���C���[��������
        {
            m_IsPlayerAtExit = true; // �t�F�[�h�J�n
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void Update()
    {
        if (m_IsPlayerAtExit) // �o���ɓ��B�����ꍇ
        {
            EndLevel(exitBackgroundImageCanvasGroup, false); // �t�F�[�h�A�E�g, �Q�[���I��

        } else if(m_IsPlayerCaught){ // �߂܂����ꍇ

            EndLevel(caugthBackgroundImageCanvasGroup, true); // �t�F�[�h�A�E�g,�ċN���\

        }
    }

    /// <summary>
    /// Canvas Group���t�F�[�h���Ă���A�Q�[�����I������
    /// </summary>
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        m_Timer += Time.deltaTime; // �^�C�}�[�̃J�E���g�A�b�v

        imageCanvasGroup.alpha = m_Timer / fadeDuration; // CanvasGround.alfa��UI�̓��߂��X�N���v�g����܂Ƃ߂Ē���

        if (m_Timer > fadeDuration + displayImageDuration) // �^�C�}�[���������Ԃ������
        {
            if (doRestart)//�ĊJ����ꍇ
            {
                SceneManager.LoadScene(0); // �V�[���̓ǂݍ���
            }
            else�@// ���Ȃ��ꍇ
            {
                Application.Quit(); // �I��
            }
        }
    }

}
