using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //获取组件
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
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Respawn")
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Respawn")
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}