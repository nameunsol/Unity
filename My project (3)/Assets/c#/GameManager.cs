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
        // �̱��� ���� ����
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
        // UI�� ���� ���� �� ������Ʈ
        gemCount++;
        gemCountText.text = "Gem Count: " + gemCount;
    }
}
