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
            dialogBox.text = "���԰���C�¶�ͨ����~";
            if (Input.GetKey(KeyCode.C))
                dialogBox.text = "Bravo!";
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("Exit");
            dialogBox.text = "�ڲݵ��л�����Ŷ";
        }

    }
}
