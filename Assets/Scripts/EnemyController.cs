using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    Animator animator;
    private Rigidbody rb;
    private bool flag = false;
    public GameObject play1;
    public GameObject play2;
    public GameObject enemy1;
    public GameObject rayhit;
    public GameObject t;
    public GameObject s;
    public GameObject text;
    public Slider slider;

    public float value = 0f;
    public float speed;//移动速度
    public float rotat;//旋转方向
    public bool isGround;//是否在地面
    public float horizontalmove = 5f;
    float angle = 90f;
    float angle2 = 90f;
    public float x, y;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = enemy1.GetComponent<Animator>();
    }

    void Update()
    {
        Ray ray = new Ray(rayhit.transform.position, rayhit.transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log("检测到物体");

            Debug.LogFormat("{0}", hit.collider.gameObject.tag);

            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("检测到Player");
                if (value < 1f)
                {
                    value += 0.002f;
                }
                if (value > 0.98f)
                {
                    GameOver();
                }
                speed = 0f;
                animator.ResetTrigger("find1");
                animator.SetTrigger("find");
            }
            else
            {
                speed = 1f;
                animator.SetTrigger("find1");
                if (value > 0f)
                {
                    value -= 0.0002f;
                }
            }
            if (value > 0f)
            {
                t.SetActive(true);
                s.SetActive(true);
            }
            else
            {
                t.SetActive(false);
                s.SetActive(false);
            }
            slider.value = value;
        }
        

    }

    private void GameOver()
    {
        text.SetActive(true);
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

        if (direction.x > 0.01f)
        {                
            enemy1.transform.localRotation = Quaternion.Euler(0, 90 - angle, 0);
        }
        if (direction.x < -0.01f)
        {
            enemy1.transform.localRotation = Quaternion.Euler(0, -90 - angle, 0);
        } 
        transform.Translate(direction.normalized * Time.deltaTime * 1.5f * speed, Space.World);

/*
        if (flag == true )
        { 
            if (direction.magnitude > 6f)
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
        }*/
    }
}
