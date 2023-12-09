using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectGem();
        }
    }

    private void CollectGem()
    {
        GameManager.Instance.IncreaseGemCount();
        Destroy(gameObject);
    }
}
