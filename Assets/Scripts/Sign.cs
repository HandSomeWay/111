using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject UI;
    bool f1 = false, f2 = false, f3 = false, f4 = false, f5 = false;
    private void Update()
    {

        if (!f1 && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
        { 
            image1.SetActive(false);
            image2.SetActive(true);
            f1 = true;
        }
        if(!f2 && Input.GetKeyDown(KeyCode.J))
        {
            image2.SetActive(false);
            image3.SetActive(true);
            f2 = true;
        }
        if(!f4 && Input.GetKeyDown(KeyCode.C))
        {
            image4.SetActive(false);
            image5.SetActive(true);
            f4 = true;
        }
        if(f4 && f1 && f2&&f3&&!f5 && (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D)))
        {
            image5.SetActive(false);
            image2.SetActive(false);
            f5 = true;
        }
        if (ModeController.Victory) UI.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!f3 )
        {
            image3.SetActive(false);
            image4.SetActive(true);
            f3 = true;
        }
        
    }
}
