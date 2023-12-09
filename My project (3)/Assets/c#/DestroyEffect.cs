using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float destroyTime = 1.5f;
    float currentTime = 0;

    void Update()
    {
        // ���� ��� �ð��� ���ŵ� �ð��� �ʰ��ϸ� �ڱ� �ڽ��� �����Ѵ�.
        if (currentTime > destroyTime)
        {
            Destroy(gameObject);
        }
        // ��� �ð��� �����Ѵ�.
        currentTime += Time.deltaTime;
    }

}
