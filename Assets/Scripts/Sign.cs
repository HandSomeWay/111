using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public Text dialogBox;
    void Start()
    {
        dialogBox.text = "快到我这来~按下A或D左右移动";
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("Enter");
            dialogBox.text = "试试按下J跳过箱子吧";
            if (Input.GetKey(KeyCode.J))
                dialogBox.text = "Bravo!";
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("Exit");
            dialogBox.text = "";
        }

    }
    
}
