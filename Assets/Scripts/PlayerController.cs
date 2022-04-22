using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb1; 
    

    public float speed;//移动速度
    public float accspeed;//加速度
    public float jumpForce;//跳跃的力
    public float gravity;//重力
    public bool isGround;//是否在地面

    void Awake() 
   {
        //获取组件
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
        rb1.velocity = new Vector2(horizontalmove * speed, rb1.velocity.y);//移动
        if (Input.GetKey("left shift"))
            rb1.velocity = new Vector2(horizontalmove * speed * accspeed, rb1.velocity.y);//shift加速
    }
    void Jump()
    {
        if(isGround)
            rb1.velocity= new Vector2(rb1.velocity.x, jumpForce);//跳跃
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
