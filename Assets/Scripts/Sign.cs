using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public Text dialogBox;
    void Start()
    {
        dialogBox.text = "�쵽������~\n����A��D�����ƶ�";
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
            dialogBox.text = "������Ծ��J����";
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
