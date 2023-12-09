using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text gemCountText;
    private int gemCount = 0;

    private void Awake()
    {
        // 싱글톤 패턴 적용
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseGemCount()
    {
        // UI의 숫자 증가 및 업데이트
        gemCount++;
        gemCountText.text = "Gem Count: " + gemCount;
    }
}
