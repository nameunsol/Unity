using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform을 저장하기 위한 변수
    private NavMeshAgent navMeshAgent; // NavMeshAgent 컴포넌트를 저장하기 위한 변수

    void Start()
    {
        // NavMeshAgent 컴포넌트 초기화
        navMeshAgent = GetComponent<NavMeshAgent>();

        // 플레이어의 Transform 가져오기
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        // 플레이어가 존재하면 몬스터를 따라가도록 설정
        if (player != null)
        {
            // 플레이어의 위치를 목적지로 설정
            navMeshAgent.SetDestination(player.position);
        }
    }
}
