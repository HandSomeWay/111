using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sign2 : MonoBehaviour
{
    public Text dialogBox;
    public GameObject image;
    void Start()
    {
        image.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "NPC")
        {
            image.SetActive(true);
            dialogBox.text = "���԰���C�¶�ͨ����~";
            if (Input.GetKey(KeyCode.C))
                dialogBox.text = "Bravo!";
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            image.SetActive(true);
            Debug.Log("Exit");
            dialogBox.text = "�ڲݵ��л�����Ŷ";
        }

    }
}
