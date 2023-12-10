using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackCollider : MonoBehaviour
{
    private Monster monster;

    private void Start() 
    {
        monster = GetComponentInParent<Monster>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            monster.isAttack = true;
            monster.Attack();        
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Player") && !monster.playerHit)
        {
            monster.isAttack = true;
            monster.Attack();
            monster.playerHit = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            monster.isAttack = false;
        }
    }
}
