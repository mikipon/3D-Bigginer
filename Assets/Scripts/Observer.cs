using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;        //playerのTransformをチェックする
    public GameEnding gameEnding;   //GameEndingメソッド

    bool m_IsPlayerInRange;         //トリガー内にいるか判定用

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = true; // トリガー内にいる
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false; // トリガー内にいない
        }
    }

    void Update()
    {
        // もし実際にプレイヤーが範囲内にいる場合
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up; // ベクトル計算でプレイヤー位置を把握+1目線を上げる
            Ray ray = new Ray(transform.position, direction); // 光線作成（原点、方向）
            RaycastHit raycastHit;  // ヒットしたコライダーを制限用

            // 何かにヒットした
            if (Physics.Raycast(ray, out raycastHit)) // outでreturnと同じように情報を取得できる(帰ってきたboolがraycastHitに入ってる)
            {
                //プレイヤーがヒットしたら
                if(raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer(); //　プレイヤーを捕まえた
                }
            }

        }   
    }

}
