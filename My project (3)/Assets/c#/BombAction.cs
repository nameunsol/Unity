using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;
    public int bombDamage;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject eff = Instantiate(bombEffect);
        eff.transform.position = transform.position;
        
        if(collision.gameObject.CompareTag("monster"))
        {
            Monster monster = collision.gameObject.GetComponent<Monster>();
            monster.hp -= bombDamage;
            monster.isHit = true;
            Debug.Log($"Hit Bomb Monster");
        }
        Destroy(gameObject);
    }
}
