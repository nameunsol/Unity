using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    ParticleSystem ps;
    public PlayerFire playerFire;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.CompareTag("monster"))
        {
            Monster monster = other.GetComponent<Monster>();
            monster.hp -= playerFire.gunPower;
            monster.isHit = true;
            Debug.Log($"Hit Monster");
        }
    }

}
