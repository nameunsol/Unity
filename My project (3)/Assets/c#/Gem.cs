using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾�� �浹 �� ����
            CollectGem();
        }
    }

    private void CollectGem()
    {
        // UI�� ���� ���� �� ���� ����
        GameManager.Instance.IncreaseGemCount();
        Destroy(gameObject);
    }
}
