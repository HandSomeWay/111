using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb1;
    private Animator Amt;

    public GameObject Model_A;
    public float speed;//�ƶ��ٶ�
    public float jumpForce;//��Ծ����
    public float gravity;//����
    public bool isGround;//�Ƿ��ڵ���

    void Awake() 
   {
        //��ȡ���
        rb1=GetComponent<Rigidbody>();
        Amt = Model_A.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            Jump();
        AnimationChg();
    }
    void FixedUpdate()
    {
        GroundMovement();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trap")
        {
            Amt.SetTrigger("Dead");
            ModeController.GameOver = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Finish")
            ModeController.Victory = true;
        if (other.tag == "Ground")
            isGround = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
            isGround = false;
    }
    void GroundMovement()
    {
        int dirHor = 0;
        if (Input.GetKey(KeyCode.A)) dirHor = -1;
        else if (Input.GetKey(KeyCode.D)) dirHor = 1;
        if (dirHor == 1) transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        if (dirHor == -1) transform.rotation = Quaternion.Euler(new Vector3(0f, -180f, 0f));
        if (dirHor != 0) Amt.SetBool("Move", true);
        else Amt.SetBool("Move", false);
        rb1.velocity = new Vector2(dirHor  * speed, rb1.velocity.y);//�ƶ�
    }
    void Jump()
    {
        if(isGround)
            rb1.velocity= new Vector2(rb1.velocity.x, jumpForce);//��Ծ
        isGround = false;
    }
    void AnimationChg()
    {
        Amt.SetFloat("Speed", Mathf.Abs(rb1.velocity.x));
        Amt.SetFloat("Jump", rb1.velocity.y);
    }
}
