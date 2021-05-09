using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration         = 1f;              //fフェードが発生する時間
    public float displayImageDuration = 1f;
    public GameObject player;                            // 参照
    public CanvasGroup exitBackgroundImageCanvasGroup;   // プレイヤーが脱出した場合に表示される画像用
    public CanvasGroup caugthBackgroundImageCanvasGroup; // プレイヤーがキャッチされた場合に表示される新しい画像用

    bool m_IsPlayerAtExit; //出口に到達したかどうか
    bool m_IsPlayerCaught; //キャッチされたかどうか
    float m_Timer;         //タイマー、フェードする前にゲームが終了しないように

    /// <summary>
    /// 当たり判定（入った！）
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) // 入ったゲームオブジェクトがプレイヤーだったら
        {
            m_IsPlayerAtExit = true; // フェード開始
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void Update()
    {
        if (m_IsPlayerAtExit) // 出口に到達した場合
        {
            EndLevel(exitBackgroundImageCanvasGroup, false); // フェードアウト, ゲーム終了

        } else if(m_IsPlayerCaught){ // 捕まった場合

            EndLevel(caugthBackgroundImageCanvasGroup, true); // フェードアウト,再起動可能

        }
    }

    /// <summary>
    /// Canvas Groupをフェードしてから、ゲームを終了する
    /// </summary>
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        m_Timer += Time.deltaTime; // タイマーのカウントアップ

        imageCanvasGroup.alpha = m_Timer / fadeDuration; // CanvasGround.alfaはUIの透過をスクリプトからまとめて調整

        if (m_Timer > fadeDuration + displayImageDuration) // タイマーが持続時間すぎると
        {
            if (doRestart)//再開する場合
            {
                SceneManager.LoadScene(0); // シーンの読み込み
            }
            else　// しない場合
            {
                Application.Quit(); // 終了
            }
        }
    }

}
