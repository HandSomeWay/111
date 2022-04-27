using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject play1;
    public GameObject play2;
    public GameObject enemy1;

    public float speed;//移动速度
    public float rotat;//旋转方向
    public bool isGround;//是否在地面
    public float horizontalmove = 5;
    float angle = 90f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            horizontalmove = -horizontalmove;
            rotat = -rotat;//移动速度
            enemy1.transform.Rotate(new Vector3(0, 180, 0), Space.Self);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
            isGround = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
            isGround = false;
    }

    void FixedUpdate()
    {
        if (ModeController.ModeX)
        {
            MoveMode1();
        }
        else
        {
            MoveMode2();
        }
    }

    void MoveMode1()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        enemy1.transform.rotation = Quaternion.Euler(0, rotat, 0);
        if (isGround)
        {
            rb.velocity = new Vector3(horizontalmove * speed, 0, 0);
        }
    }

    void MoveMode2()
    {
        transform.rotation = Quaternion.Euler(-90, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);       
        var direction = play2.transform.position - transform.position;
        
        if (direction.x > 0.0001)
        {
            angle = 180f / Mathf.PI * Mathf.Asin(direction.y / direction.x);
            enemy1.transform.localRotation = Quaternion.Euler(0, 90 - angle, 0);
        }
        if (direction.x < -0.0001)
        {
            angle = 180f / Mathf.PI * Mathf.Asin(direction.y / direction.x);
            enemy1.transform.localRotation = Quaternion.Euler(0, -90 - angle, 0);
        }

        transform.Translate(direction.normalized * Time.deltaTime * speed, Space.World);
    }
}
