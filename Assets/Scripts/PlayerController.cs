using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb1; 
    

    public float speed;//�ƶ��ٶ�
    public float accspeed;//���ٶ�
    public float jumpForce;//��Ծ����
    public float gravity;//����
    public bool isGround;//�Ƿ��ڵ���

    void Awake() 
   {
        //��ȡ���
        rb1=GetComponent<Rigidbody>();
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
    }
    void FixedUpdate()
    {
        GroundMovement();
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
    void GroundMovement()
    {
        int horizontalmove = 0;
        if (Input.GetKey(KeyCode.A)) horizontalmove = -1;
        else if (Input.GetKey(KeyCode.D)) horizontalmove = 1;
        rb1.velocity = new Vector2(horizontalmove * speed, rb1.velocity.y);//�ƶ�
        if (Input.GetKey("left shift"))
            rb1.velocity = new Vector2(horizontalmove * speed * accspeed, rb1.velocity.y);//shift����
    }
    void Jump()
    {
        if(isGround)
            rb1.velocity= new Vector2(rb1.velocity.x, jumpForce);//��Ծ
        isGround = false;
    }
    //void Gravity()
    //{
    //    if(!isGround)
    //    {
    //        rb1.velocity = new Vector2(rb1.velocity.x, gravity);
    //    }
    //}
}
