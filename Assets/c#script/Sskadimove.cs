using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sskadimove : MonoBehaviour
{
    // 获取组件
    private Rigidbody2D rb1;
    private Collider2D coll1;
    private Animator animo1;

    public float speed;//移动速度
    public float accspeed;//加速度
    public float jumpForce;//跳跃的力
    public Transform groundCheck;//获取地面
    public LayerMask ground;//地面碰撞检测

    private bool isGround;//是否在地面
    public bool isJump;//是否在跳跃，用来控制跳跃动画
    public bool jumpPressed;//判断是否按下跳跃键
    public int jumpCount;//跳跃次数
    private int savejumpcount;//记录跳跃次数
     void Start() 
    {
        savejumpcount=jumpCount;
    }
   void Awake() 
   {
        //获取组件
        rb1=GetComponent<Rigidbody2D>();
        coll1=GetComponent<Collider2D>();
        animo1=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   isGround=Physics2D.OverlapCircle(groundCheck.position,0.1f,ground);//检测是否在地面
        //判断接收跳跃 且 跳跃次数大于0
        if(Input.GetButtonDown("Jump")&&jumpCount>0)
        {   
            jumpPressed=true;//按下了跳跃键
        }
        Jump();
        SwitchAnim();
    }


    void FixedUpdate() 
    {   
        
        GroundMovement();
    }

    //移动
    void GroundMovement()
    {
        float horizontalmove=Input.GetAxisRaw("Horizontal");//返回1，0，-1,右返回1
        rb1.velocity=new Vector2(horizontalmove*speed,rb1.velocity.y);//移动
        if(Input.GetKey("left shift"))
        rb1.velocity=new Vector2(horizontalmove*speed*accspeed,rb1.velocity.y);//shift加速
        if(horizontalmove==1)
        {
            transform.rotation=Quaternion.Euler(Vector3.up*95);//1的话y转到95度实现旋转
        }
        else if(horizontalmove==-1)
        {
            transform.rotation=Quaternion.Euler(Vector3.up*-95);//-1的话y转到-95度实现旋转
        }
        if(horizontalmove==0)
        {
            transform.rotation=Quaternion.Euler(Vector3.up*180);
        }
    }

    //跳跃
    void Jump()
    {
        if(isGround)
        {
            isJump=false;
            jumpCount=savejumpcount;
        }
        if(jumpPressed&&jumpCount>0)//按下跳跃
        {   
            jumpCount--;//跳跃次数减1
            isJump=true;
            rb1.velocity=new Vector2(rb1.velocity.x,jumpForce);//跳跃
            jumpPressed=false;
        }
    }

    //设置动画
    void SwitchAnim()
    {
        animo1.SetFloat("Speed",Math.Abs(rb1.velocity.x));//传递横轴移动速度的绝对值

        if(isGround)//在地上结束跳跃
        {
            animo1.SetBool("jump1",false);
            animo1.SetBool("down",false);
        }
        if(!isGround&&rb1.velocity.y>0)
        {
            animo1.SetBool("jump1",true);
        }
        
    }
}
