using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //�@NavMeshAgent�N���X�ɃA�N�Z�X�\

public class WaypointPatrol : MonoBehaviour
{

    public NavMeshAgent NavMeshAgent;
    public Transform[] waypoints;

    int m_CurrentWayppointIndex;

    void Start()
    {
        NavMeshAgent.SetDestination(waypoints[0].position); // ������
    }

    void Update()
    {
        if(NavMeshAgent.remainingDistance < NavMeshAgent.stoppingDistance) // �ړI�n�ɓ����������i�ݒ肵����~���������Z�����ǂ����j
        {
            m_CurrentWayppointIndex = (m_CurrentWayppointIndex + 1) % waypoints.Length; // �z��ƈꏏ�ɂȂ�����0�ɂȂ�
            NavMeshAgent.SetDestination(waypoints[m_CurrentWayppointIndex].position);
        }
    }
}
