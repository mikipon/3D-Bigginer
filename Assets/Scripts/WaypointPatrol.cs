using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //　NavMeshAgentクラスにアクセス可能

public class WaypointPatrol : MonoBehaviour
{

    public NavMeshAgent NavMeshAgent;
    public Transform[] waypoints;

    int m_CurrentWayppointIndex;

    void Start()
    {
        NavMeshAgent.SetDestination(waypoints[0].position); // 初期化
    }

    void Update()
    {
        if(NavMeshAgent.remainingDistance < NavMeshAgent.stoppingDistance) // 目的地に到着したか（設定した停止距離よりも短いかどうか）
        {
            m_CurrentWayppointIndex = (m_CurrentWayppointIndex + 1) % waypoints.Length; // 配列と一緒になったら0になる
            NavMeshAgent.SetDestination(waypoints[m_CurrentWayppointIndex].position);
        }
    }
}
