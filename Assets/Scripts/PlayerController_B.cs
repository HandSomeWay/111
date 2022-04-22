using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_B : MonoBehaviour
{
    public Collider c;
    public LayerMask whatStopsMovement;
    public Transform movePoint;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) Interact();
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
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position,movePoint.position)<=0.5f)
        {
            int dirVer, dirHor;
            dirVer = dirHor = 0;
            if (Input.GetKey(KeyCode.UpArrow)) dirVer = 1;
            else if (Input.GetKey(KeyCode.DownArrow)) dirVer = -1;
            if (Input.GetKey(KeyCode.RightArrow)) dirHor = 1;
            if (Input.GetKey(KeyCode.LeftArrow)) dirHor = -1;
            if (Mathf.Abs(dirHor)==1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(dirHor, 0f, 0f) , 0.9f,  whatStopsMovement))
                {
                    movePoint.position += new Vector3(dirHor, 0f, 0f);
                }
            }
            else if(Mathf.Abs(dirVer)==1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, dirVer, 0f) , .9f,  whatStopsMovement) )
                {
                    movePoint.position += new Vector3(0f, dirVer, 0f);
                }
            }
        }
    }
}
