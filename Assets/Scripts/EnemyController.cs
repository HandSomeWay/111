using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject play1;
    public GameObject play2;
    public float speed;//�ƶ��ٶ�
    public bool isGround;//�Ƿ��ڵ���
    public float horizontalmove = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
            horizontalmove = -horizontalmove;
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
        if (isGround)
        {
            rb.velocity = new Vector3(horizontalmove * speed, 0, 0);
        }
    }

    void MoveMode2()
    {
        rb.velocity = new Vector3(0, 0, 0);       
        var direction = play2.transform.position - transform.position;
        transform.Translate(direction.normalized * Time.deltaTime * speed, Space.World);
    }
}
