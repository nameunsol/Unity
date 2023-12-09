using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public static SpawnMonster Instance;
    
    public Transform monsterParent;
    public GameObject[] monsters;
    public List<GameObject> aliveMonsters;

    public Vector3 minPosition; // 생성할 위치의 최소값
    public Vector3 maxPosition; // 생성할 위치의 최대값
    public LayerMask obstacleLayer; // 정적인 오브젝트의 레이어

    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start() 
    {
        StartCoroutine(SpawnMonsterCoroutine());
    }

    private IEnumerator SpawnMonsterCoroutine()
    {
        while(true)
        {
            yield return new WaitUntil(() => aliveMonsters.Count < 10);

            int randomInt = Random.Range(0, 2);
            Vector3 spawnPoint = GetRandomPosition();
            GameObject monster = Instantiate(monsters[randomInt], spawnPoint, Quaternion.identity);
            monster.transform.SetParent(monsterParent);

            aliveMonsters.Add(monster);

            yield return new WaitForSeconds(3f);
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition;

        // 반복해서 유효한 위치 찾기
        do
        {
            float randomX = Random.Range(minPosition.x, maxPosition.x);
            float randomY = Random.Range(minPosition.y, maxPosition.y);
            float randomZ = Random.Range(minPosition.z, maxPosition.z);

            randomPosition = new Vector3(randomX, randomY, randomZ);
        } while (IsOverlappingWithObstacle(randomPosition));

        return randomPosition;
    }

    private bool IsOverlappingWithObstacle(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 1f, obstacleLayer);

        // 겹치는 콜라이더가 있으면 true 반환
        return colliders.Length > 0;
    }

    public bool MonsterDie(GameObject monster)
    {
        if(aliveMonsters.Contains(monster))
        {
            aliveMonsters.Remove(monster);
            Destroy(monster);
            return true;
        }
        else
        {
            return false;
        }
    }
}
