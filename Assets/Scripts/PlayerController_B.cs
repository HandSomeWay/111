using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_B : MonoBehaviour
{
    private Rigidbody rb;
    private Animator Amt;

    public GameObject Model_B;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        //获取组件
        rb = GetComponent<Rigidbody>();
        Amt = Model_B.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) Interact();
        AnimationChg();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Interact()
    {
        Debug.Log("Interact!");
    }
    void Move()
    {
        int dirVer = 0;
        int dirHor = 0;
        if (Input.GetKey(KeyCode.UpArrow)) dirVer = 1;
        else if (Input.GetKey(KeyCode.DownArrow)) dirVer = -1;
        if (Input.GetKey(KeyCode.RightArrow)) dirHor = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) dirHor = -1;
        if (dirHor == 0 && dirVer == -1) transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f));
        if (dirHor == 0 && dirVer == 1) transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        if (dirHor == -1 && dirVer == 0) transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
        if (dirHor == 1 && dirVer == 0) transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
        if (dirHor == 1 && dirVer == 1) transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -45f));
        if (dirHor == 1 && dirVer == -1) transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -135f));
        if (dirHor == -1 && dirVer == -1) transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 135f));
        if (dirHor == -1 && dirVer == 1) transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 45f));
        if (dirHor != 0 || dirVer != 0) Amt.SetBool("Move", true);
        else Amt.SetBool("Move", false);
        rb.velocity = new Vector3(dirHor * speed, dirVer*speed,rb.velocity.z);//移动
    }
    void AnimationChg()
    {
        Amt.SetFloat("Speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
            Amt.SetBool("Push", true);
        else Amt.SetBool("Push", false);
    }
}
