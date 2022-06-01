using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyController1 : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    public GameObject play1;
    public GameObject play2;
    public GameObject enemy1;
    public GameObject rayhit;
    public GameObject light;
    public GameObject text;
    public GameObject slider;
    public Slider slider1;
    NavMeshAgent agent;

    private bool Move = true;
    public float value = 0f;
    public float speed;
    public float rotat;
    public bool isGround;
    public float horizontalmove = 5f;
    float angle = 90f;
    private bool flag = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = enemy1.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Move) {
            Ray ray = new Ray(rayhit.transform.position, rayhit.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (Move && hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("¼ì²âµ½Player");
                    if (value < 1f)
                    {
                        value += 0.002f;
                    }
                    if (value > 0.98f)
                    {
                        ModeController.GameOver = true;
                    }
                    if (ModeController.ModeX)
                    {
                        speed = 0f;
                    }
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
                    text.SetActive(true);
                    slider.SetActive(true);
                }
                else
                {
                    text.SetActive(false);
                    slider.SetActive(false);
                }
                slider1.value = value;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ModeController.ModeX)
        {
            if (other.tag == "Wall")
            {
                horizontalmove = -horizontalmove;
                rotat = 180 - rotat;
                enemy1.transform.Rotate(new Vector3(0, 180, 0), Space.Self);
            }
            if (other.tag == "Trap")
            {
                animator.SetTrigger("Dead");
                Move = false;
                light.SetActive(false);
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
        if (Move)
        {
            if (ModeController.ModeX)
            {
                rb.AddForce(new Vector3(0f, 0f, -9f));
                MoveMode1();
            }
            else
            {
                MoveMode2();
            }
        }

    }

    void MoveMode1()
    {
        rb.useGravity = false;  
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        transform.rotation = Quaternion.Euler(90, 0, 0);
        enemy1.transform.rotation = Quaternion.Euler(rotat, 90, 90);
        if (isGround)
        {
            rb.velocity = new Vector3(horizontalmove * speed, 0, 0);
        }
    }

    void MoveMode2()
    {
        if (flag)
        {
            enemy1.transform.rotation = Quaternion.Euler(-90, 180, 0);
            flag = false;
        }
        rb.useGravity = true;
        //transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);
        agent.SetDestination(play2.transform.position);

/*        var direction = play2.transform.position - transform.position;
        angle = 180f / Mathf.PI * Mathf.Asin(direction.y / direction.x);

        if (direction.x > 0.01f)
        {
            enemy1.transform.localRotation = Quaternion.Euler(0, 90 - angle, 0);
        }
        if (direction.x < -0.01f)
        {
            enemy1.transform.localRotation = Quaternion.Euler(0, -90 - angle, 0);
        }
        transform.Translate(direction.normalized * Time.deltaTime * 1.5f * speed, Space.World);*/
    }
}
