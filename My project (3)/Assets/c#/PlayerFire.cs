using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    // �߻� ��ġ
    public GameObject firePosition;
    // ��ô ���� ������Ʈ
    public GameObject bombFactory;
    public GameObject bubbleEffect;
    // ��ô �Ŀ�
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
        // ���콺 ������ ��ư�� �Է¹޴´�.
        if (Input.GetMouseButtonDown(1))
        {
            // ����ź ������Ʈ�� ������ �� ����ź�� ���� ��ġ�� �߻� ��ġ�� �Ѵ�.
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;
            // ����ź ������Ʈ�� Rigidbody ������Ʈ�� �����´�.
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            // ī�޶��� ���� �������� ����ź�� �������� ���� ���Ѵ�.
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
        // �Ѿ��� �����ϰ� �߻�� ��ġ�� ������ ����
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Rigidbody ������Ʈ�� �ִ��� Ȯ�� �� ���
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            // �Ѿ��� ī�޶� �ٶ󺸴� �������� �߻�
            bulletRb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }

        // �Ѿ��� ���� �ð� �Ŀ� �ڵ����� ���ŵǵ��� ����
        Destroy(bullet, bulletLifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���� ���Ϳ� �浹�ߴٸ� ���� �ð� ���� ���߾��ٰ� �Ѿ� ����
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

        // �Ѿ��� ����
        Destroy(gameObject);
    }
}
