using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class binkuai : MonoBehaviour
{
    private Animator animator;
    public GameObject bin; 

    void Start()
    {
        animator = bin.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            animator.SetTrigger("diaoluo");
    }
}
