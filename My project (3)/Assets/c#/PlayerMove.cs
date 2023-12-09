using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;
    //ĳ���� ��Ʈ�ѷ� ������Ʈ �޾ƿ���
    CharacterController cc;
    //�߷º���
    public float gravity = -20f;
    //���� �ӷ� ����
    float yVelocity = 0;
    //������ ����
    public float jumpPower = 10f;
    //���� ���� ����
    public bool isJumping = false;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ű����wasd ��ư�� �Է��ϸ� ĳ���͸� �� �������� �̵���Ű�� �ʹ�
        //Ű���� �����̽��ٸ� �θ��� ������Ű�� �ʹ�

        //1 ����� �Է��� �޴´�.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //2 �̵� ������ �����Ѵ�.
        Vector3 dir = new Vector3(h, 0, v);
        //2.1 ���� ī�޶� �������� ������ ��ȯ�Ѵ�.
        dir = Camera.main.transform.TransformDirection(dir);

        //2.2 ���� ���� ���̾��� �ٽ� �ٴڿ� �����ߴٸ�
        if (cc.isGrounded)
        {
            yVelocity = 0;
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpPower;
            }
        }
        //2.3 ���� Ű���� ���� �����̽��ٰ� ������ ������ ���� ���� ���¶��

        yVelocity += (gravity * Time.deltaTime);

        dir.y = yVelocity;
        //p=p0+vt
        cc.Move(dir * moveSpeed * Time.deltaTime);
        //transform.position += dir * moveSpeed * Time.deltaTime;
    }


}
