using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f; //fフェードが発生する時間
    public float displayImageDuration = 1f;

    public GameObject player; //参照
    public CanvasGroup exitBackgroundImageCanvasGroup;

    bool m_IsPlayerAtExit; //フェードインを開始するかどうか
    float m_Timer; //タイマー、フェードする前にゲームが終了しないように

    //当たり判定（入った！）
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel();
        } 
    }

    /// <summary>
    /// Canvas Groupをフェードしてから、ゲームを終了する
    /// </summary>
    void EndLevel()
    {
        m_Timer += Time.deltaTime; //タイマーのカウントアップ

        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)//タイマーが持続時間すぎると
        {
            Application.Quit();//終了
        }
    }

}
