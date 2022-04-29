using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sign2 : MonoBehaviour
{
    public Text dialogBox;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            dialogBox.text = "试试按下C下蹲通过吧~";
            if (Input.GetKey(KeyCode.C))
                dialogBox.text = "Bravo!";
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("Exit");
            dialogBox.text = "在草地中会隐身哦";
        }

    }
}
