using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_B : MonoBehaviour
{
    private Rigidbody rb;

    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        //获取组件
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) Interact();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Interact()
    {
        Debug.Log("Interact!");
    }
    void Move()
    {
        int dirVer = 0;
        int dirHor = 0;
        if (Input.GetKey(KeyCode.UpArrow)) dirVer = 1;
        else if (Input.GetKey(KeyCode.DownArrow)) dirVer = -1;
        if (Input.GetKey(KeyCode.RightArrow)) dirHor = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) dirHor = -1;
        rb.velocity = new Vector3(dirHor * speed, dirVer*speed,rb.velocity.z);//移动
    }
}
