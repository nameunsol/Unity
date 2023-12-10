using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Monster : MonoBehaviour
{
    private NavMeshAgent navMeshAgent; // NavMeshAgent 컴포넌트를 저장하기 위한 변수
    private Animator anim;
    
    public PlayerMove player; // 플레이어의 Transform을 저장하기 위한 변수
    public int hp;
    public int attackDamage;
    public bool isAttack;
    public bool isDie;
    public bool isWalk;
    public bool isHit;
    public bool playerHit;

    public float detectionRadius = 2f;

    void Start()
    {
        // NavMeshAgent 컴포넌트 초기화
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        // 플레이어의 Transform 가져오기
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        }

        Physics.IgnoreCollision(GetComponent<CapsuleCollider>(), player.GetComponent<CharacterController>().GetComponent<Collider>(), true);
    }

    void Update()
    {
        // 플레이어가 존재하면 몬스터를 따라가도록 설정
        if (player != null || !isDie)
        {
            // 플레이어의 위치를 목적지로 설정
            // navMeshAgent.SetDestination(player.position);
            navMeshAgent.destination = player.transform.position;
        }

        if (hp <= 0) isDie = true;

        if(isHit)
        {
            Hit();
        }

        if(!isAttack)
        {
            Walk();
        }

        if(isDie)
        {
            Die();
        }
    }

    private void Walk()
    {
        anim.SetBool("isAttack", false);
    }

    public void Attack()
    {
        anim.SetBool("isAttack", true);
        transform.LookAt(player.transform);

        StartCoroutine(AttackCor());
    }

    private void Hit()
    {
        anim.SetTrigger("isHit");
        StartCoroutine(MonsterColor());
        isHit = false;
    }

    private void Die()
    {
        anim.SetBool("isDie", true);
        StartCoroutine(MonsterDie());

        navMeshAgent.isStopped = true;
    }

    private IEnumerator AttackCor()
    {
        yield return new WaitForSeconds(1f);

        if(isAttack)
        {
            player.playerHP -= attackDamage;
        }

        yield return new WaitForSeconds(0.5f);
        playerHit = false;
    }

    private IEnumerator MonsterColor()
    {
        SkinnedMeshRenderer mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        if (mesh != null) mesh.material.color = Color.red;
        navMeshAgent.isStopped = true;
        yield return new WaitForSeconds(0.1f);
        if (mesh != null) mesh.material.color = Color.white;
        navMeshAgent.isStopped = false;
    }

    private IEnumerator MonsterDie()
    {
        var collider = GetComponent<CapsuleCollider>();
        collider.isTrigger = true;

        yield return new WaitForSeconds(3f);
        SpawnMonster.Instance.MonsterDie(gameObject);
    }
}
