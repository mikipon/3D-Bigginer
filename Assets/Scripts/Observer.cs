using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;        //player��Transform���`�F�b�N����
    public GameEnding gameEnding;   //GameEnding���\�b�h

    bool m_IsPlayerInRange;         //�g���K�[���ɂ��邩����p

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = true; // �g���K�[���ɂ���
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false; // �g���K�[���ɂ��Ȃ�
        }
    }

    void Update()
    {
        // �������ۂɃv���C���[���͈͓��ɂ���ꍇ
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up; // �x�N�g���v�Z�Ńv���C���[�ʒu��c��+1�ڐ����グ��
            Ray ray = new Ray(transform.position, direction); // �����쐬�i���_�A�����j
            RaycastHit raycastHit;  // �q�b�g�����R���C�_�[�𐧌��p

            // �����Ƀq�b�g����
            if (Physics.Raycast(ray, out raycastHit)) // out��return�Ɠ����悤�ɏ����擾�ł���(�A���Ă���bool��raycastHit�ɓ����Ă�)
            {
                //�v���C���[���q�b�g������
                if(raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer(); //�@�v���C���[��߂܂���
                }
            }

        }   
    }

}
