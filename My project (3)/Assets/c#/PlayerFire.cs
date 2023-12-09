using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    // 발사 위치
    public GameObject firePosition;
    // 투척 무기 오브젝트
    public GameObject bombFactory;
    public GameObject bubbleEffect;
    // 투척 파워
    public float throwPower = 30f;

    public GameObject bulletPrefab;
    public float bulletSpeed = 50f;
    public float bulletLifetime = 100f;
    public float freezeTimeOnHit = 0.5f;

    public ParticleSystem ps;


    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
    }


    void Update()
    {
        // 마우스 오른쪽 버튼을 입력받는다.
        if (Input.GetMouseButtonDown(1))
        {
            // 수류탄 오브젝트를 생성한 후 수류탄의 생성 위치를 발사 위치로 한다.
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;
            // 수류탄 오브젝트의 Rigidbody 컴포넌트를 가져온다.
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            // 카메라의 정면 방향으로 수류탄에 물리적인 힘을 가한다.
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);

        }
        
        if (Input.GetMouseButtonDown(0))
        {
            ps.Play();
        }
        else if(Input.GetMouseButton(0)) 
        {

        }
        else if (Input.GetMouseButtonUp(0))
        {
            ps.Stop();
        }

    }


    void Shoot()
    {
        // 총알을 생성하고 발사될 위치와 방향을 설정
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Rigidbody 컴포넌트가 있는지 확인 후 사용
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            // 총알을 카메라가 바라보는 방향으로 발사
            bulletRb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }

        // 총알이 일정 시간 후에 자동으로 제거되도록 설정
        Destroy(bullet, bulletLifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 만약 몬스터와 충돌했다면 일정 시간 동안 멈추었다가 총알 제거
        if (collision.gameObject.CompareTag("Monster"))
        {
            Rigidbody bulletRb = GetComponent<Rigidbody>();
            bulletRb.velocity = Vector3.zero;
            StartCoroutine(FreezeAndDestroy());
        }
    }
    IEnumerator FreezeAndDestroy()
    {
        yield return new WaitForSeconds(freezeTimeOnHit);

        // 총알을 제거
        Destroy(gameObject);
    }
}
