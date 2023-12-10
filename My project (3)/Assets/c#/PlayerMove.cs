using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int playerHP = 5;
    public float moveSpeed = 7f;
    CharacterController cc;
    public float gravity = -20f;
    float yVelocity = 0;
    public float jumpPower = 10f;
    public bool isJumping = false;
    public bool isDie;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = Camera.main.transform.TransformDirection(dir);

        if (cc.isGrounded)
        {
            yVelocity = 0;
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpPower;
            }
        }

        yVelocity += (gravity * Time.deltaTime);

        dir.y = yVelocity;
        //p=p0+vt
        cc.Move(dir * moveSpeed * Time.deltaTime);
        //transform.position += dir * moveSpeed * Time.deltaTime;

        if(playerHP <= 0)
        {
            isDie = true;
        }

        if(isDie) PlayerDie();
    }

    private void PlayerDie()
    {
        Debug.Log($"Player Die");
    }

}
