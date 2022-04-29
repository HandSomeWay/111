using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public Text dialogBox;
    public GameObject image;
    void Start()
    {
        dialogBox.text = "�쵽������~����A��D�����ƶ�";
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("Enter");
            image.SetActive(true);
            dialogBox.text = "���԰���J�������Ӱ�";
            if (Input.GetKey(KeyCode.J))
                dialogBox.text = "Bravo!";
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            image.SetActive(false);
            Debug.Log("Exit");
            dialogBox.text = "";
        }

    }
    
}
