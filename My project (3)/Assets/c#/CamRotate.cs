using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotSpeed = 200f;
    float mx = 0;
    float my = 0;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //1 마우스 입력 받기
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        //1.1 회전 값 변수에 마우스 입력 값만큼 미리 누적시킨다.
        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;

        //1.2 마우스 상하 이동 회전 변수(my)의 값을 -90 ~ 90 사이로 제한
        my = Mathf.Clamp(my, -90f, 90f);

        //2 마우스 입력 값을 이용해 회전 방향 결정
        transform.eulerAngles = new Vector3(-my, mx, 0);
        //Vector3 dir = new Vector3(-mouse_Y, mouse_X, 0);

        //3 회전 방향으로 물체를 회전시킨다.
        //r=r0+vt
        //transform.eulerAngles += dir * rotSpeed * Time.deltaTime;
        //4 x축 회전(상하 회전)값을 -90도~90도 사이로 제한한다.
        //Vector3 rot = transform.eulerAngles;
        //rot.x = Mathf.Clamp(rot.x, -90f, 90f);
        //transform.eulerAngles = rot;
    }
}
