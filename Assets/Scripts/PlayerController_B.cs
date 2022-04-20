using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_B : MonoBehaviour
{
    public Rigidbody rb2;

    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
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
        int dirVer,dirHor;
        dirVer = dirHor = 0;
        if (Input.GetKey(KeyCode.UpArrow)) dirVer = 1;
        else if (Input.GetKey(KeyCode.DownArrow)) dirVer = -1;
        if (Input.GetKey(KeyCode.RightArrow)) dirHor = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) dirHor = -1;

        rb2.velocity = new Vector3(dirHor * speed, dirVer * speed, rb2.velocity.z);

    }
}
