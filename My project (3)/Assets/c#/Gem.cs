using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어와 충돌 시 동작
            CollectGem();
        }
    }

    private void CollectGem()
    {
        // UI의 숫자 증가 및 보석 제거
        GameManager.Instance.IncreaseGemCount();
        Destroy(gameObject);
    }
}
