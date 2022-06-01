using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoint : MonoBehaviour
{
    public float JumpForce;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ModeController.ModeX)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;

        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
  

}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Debug.Log("Player_here");
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
    }
}
