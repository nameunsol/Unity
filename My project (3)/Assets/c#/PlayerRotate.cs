using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float rotSpeed = 200f;

    float mx = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //사용자의 마우스 입력을 받아 플레이어를 회전시키고 싶다.
        //1 마우스 좌우 입력을 받는다.
        float mouse_X = Input.GetAxis("Mouse X");

        //1.1회전 값 변수에 마우스 입력 값만큼 미리 누적시킨다.
        mx += mouse_X * rotSpeed * Time.deltaTime;
        //2. 회전 방향으로 물체를 회전시킨다.
        transform.eulerAngles = new Vector3(0, mx, 0);
    }
}
