using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class binkuai : MonoBehaviour
{
    private Animator animator;
    public GameObject bin; 
    // Start is called before the first frame update
    void Start()
    {
        animator = bin.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            animator.SetTrigger("diaoluo");
    }
}

