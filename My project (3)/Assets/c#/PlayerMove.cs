using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;
    //캐릭터 컨트롤러 컴포넌트 받아오기
    CharacterController cc;
    //중력변수
    public float gravity = -20f;
    //수직 속력 변수
    float yVelocity = 0;
    //점프력 변수
    public float jumpPower = 10f;
    //점프 상태 변수
    public bool isJumping = false;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //키보드wasd 버튼을 입력하면 캐릭터를 그 방향으로 이동시키고 싶다
        //키보드 스페이스바를 부르면 점프시키고 싶다

        //1 사용자 입력을 받는다.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //2 이동 방향을 설정한다.
        Vector3 dir = new Vector3(h, 0, v);
        //2.1 메인 카메라를 기준으로 방향을 변환한다.
        dir = Camera.main.transform.TransformDirection(dir);

        //2.2 만약 점프 중이었고 다시 바닥에 착지했다면
        if (cc.isGrounded)
        {
            yVelocity = 0;
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpPower;
            }
        }
        //2.3 만약 키보드 값이 스페이스바가 들어오고 점프를 하지 않은 상태라면

        yVelocity += (gravity * Time.deltaTime);

        dir.y = yVelocity;
        //p=p0+vt
        cc.Move(dir * moveSpeed * Time.deltaTime);
        //transform.position += dir * moveSpeed * Time.deltaTime;
    }


}
