using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject MdE;
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
    public GameObject UI;

    private bool Move = true;
    public float value = 0f;
    public float speed;
    public float rotat;
    public bool isGround;
    public float horizontalmove = 2f;
    float angle = 90f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = enemy1.GetComponent<Animator>();
    }

    void Update()
    {
        if (ModeController.GameOver || ModeController.Victory) UI.SetActive(false);
        if (Move && ModeController.ModeX) {
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
                    animator.ResetTrigger("unfind");
                    animator.SetTrigger("find");
                }
                else
                {
                    speed = 1f;
                    animator.SetTrigger("unfind");
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
        if (other.tag == "Player")
        {
            ModeController.GameOver = true;
        }
        if (ModeController.ModeX)
        {
            if (other.tag == "Wall")
            {
                horizontalmove = -horizontalmove;
                if(horizontalmove==2)
                MdE.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
                else if(horizontalmove ==-2)
                MdE.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

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
        //rb.useGravity = true;
        //transform.rotation = Quaternion.Euler(0, 0, 0);
        //transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        //enemy1.transform.rotation = Quaternion.Euler(0, rotat, 0);
        if (isGround)
        {
            rb.velocity = new Vector3(horizontalmove * speed, 0, 0);
        }
        light.SetActive(true);
        rb.useGravity = true;
    }

    void MoveMode2()
    {
        rb.useGravity = false;        
        //transform.rotation = Quaternion.Euler(-90, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);       
        var direction = play2.transform.position - transform.position;
        angle = 180f / Mathf.PI * Mathf.Asin(direction.y / direction.x);    

        if (direction.x > 0.01f)
        {
            MdE.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
        if (direction.x < -0.01f)
        {
            //enemy1.transform.localRotation = Quaternion.Euler(0, -90 - angle, 0);
            MdE.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        } 
        transform.Translate(direction.normalized * Time.deltaTime * 1.5f * speed, Space.World);
        light.SetActive(false);
        rb.useGravity =false;
    }
}
