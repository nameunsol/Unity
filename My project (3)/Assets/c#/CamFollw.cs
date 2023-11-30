using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollw : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
    }
}
