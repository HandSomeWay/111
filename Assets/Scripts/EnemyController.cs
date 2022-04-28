using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    private bool flag = false;
    public GameObject play1;
    public GameObject play2;
    public GameObject enemy1;

    public float speed;//移动速度
    public float rotat;//旋转方向
    public bool isGround;//是否在地面
    public float horizontalmove = 5f;
    float angle = 90f;
    float angle2 = 90f;
    public float x, y;
    public float timer = 3f;
    public float time = 3f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > time)
        {
            timer = 0f;
            x = Random.Range(-1f, 1f);
            y = Random.Range(-1f, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ModeController.ModeX)
        {
            if (other.tag == "Wall")
            {
                horizontalmove = -horizontalmove;
                rotat = -rotat;//移动速度
                enemy1.transform.Rotate(new Vector3(0, 180, 0), Space.Self);
            }
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
        rb.useGravity = true;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        enemy1.transform.rotation = Quaternion.Euler(0, rotat, 0);
        if (isGround)
        {
            rb.velocity = new Vector3(horizontalmove * speed, 0, 0);
        }
    }

    void MoveMode2()
    {
        rb.useGravity = false;        
        transform.rotation = Quaternion.Euler(-90, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);       
        var direction = play2.transform.position - transform.position;
        angle = 180f / Mathf.PI * Mathf.Asin(direction.y / direction.x);    

        if (flag == true )
        {   
     
            if (direction.x > 0.01f)
            {                
                enemy1.transform.localRotation = Quaternion.Euler(0, 90 - angle, 0);
            }
            if (direction.x < -0.01f)
            {
                enemy1.transform.localRotation = Quaternion.Euler(0, -90 - angle, 0);
            } 
            transform.Translate(direction.normalized * Time.deltaTime * 1.5f * speed, Space.World);
            if (direction.magnitude > 8f)
            {
                flag = false;
            }
        }
        else
        {
            angle2 = 180f / Mathf.PI * Mathf.Asin(y / x);            
            if (x > 0.01f)
            {
                enemy1.transform.localRotation = Quaternion.Euler(0, 90 - angle2, 0);
            }
            if (x < -0.01f)
            {
                enemy1.transform.localRotation = Quaternion.Euler(0, -90 - angle2, 0);
            }
            transform.Translate(0.01f * new Vector3(x, 0, y));

            if (direction.magnitude < 3f)
            {
                flag = true;
            }
        }
    }
}
