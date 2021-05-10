using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //回転速さ
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;//メンバー変数（命令規則）（この変数名のつけ方をパスカルケースと呼ぶ）
    Quaternion m_Rotation = Quaternion.identity;//デフォルト
    AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator      = GetComponent<Animator>();
        m_Rigidbody     = GetComponent<Rigidbody>();
        m_AudioSource   = GetComponent<AudioSource>();
    }

    // 一定秒数ごとによばれる
    void FixedUpdate()
    {
        //horizontal(水平)とvertical（垂直）の値を取得
        float horizontal = Input.GetAxis("Horizontal");
        float vertical 　= Input.GetAxis("Vertical");

        //ピタゴラスの定理では一番長い線が1.414であるため
        //斜めのほうが早く移動してしまうため、正規化する
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        //浮動小数点を比較し、近似している場合はFalse
        //水平変数がほぼゼロの場合、メソッドはTrueを返す
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);//横軸
        bool hasVerticalInput   = !Mathf.Approximately(vertical, 0f);//縦軸
        bool isWalking          = hasHorizontalInput || hasVerticalInput; //hasHorizo​​ntalInputまたはhasVerticalInputがtrueの場合、isWalkingはtrue

        //アニメーションをセット
        m_Animator.SetBool("IsWalking", isWalking);

        if (isWalking) // プレイヤーが歩いている場合
        {
            if (!m_AudioSource.isPlaying) // 再生されていない場合
            {
                m_AudioSource.Play();
            }
        }
        else // それ以外
        {
            m_AudioSource.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

    }

    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
