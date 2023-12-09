using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject firePosition;
    public GameObject bombFactory;
    public GameObject bubbleEffect;
    public float throwPower = 30f;
    public int gunPower = 1;

    public ParticleSystem ps;


    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            Vector3 bombDir = (Camera.main.transform.forward + new Vector3(0f, 0.5f, 0f)) * throwPower;
            rb.AddForce(bombDir, ForceMode.Impulse);

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

}
