using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraChg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(ModeController.ModeX)
        {
            //this.gameObject.transform.position = new Vector3(0f, -3f, -10f);
            //this.gameObject.transform.localEulerAngles = new Vector3(-22f, 0f, 0f);
            if(Input.GetKeyDown(KeyCode.X))
            {
                StartCoroutine(chg2());
            }


        }
        else
        {
            //this.gameObject.transform.position = new Vector3(0f, 1f, -10f);
            //this.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            if(Input.GetKeyDown(KeyCode.X))
            {
                StartCoroutine(chg1());
            }
        }
    }
    IEnumerator chg1()
    {
        float p = 0.4f, r = 2.2f;
        for(int i=1;i<=10;i++)
        {
            this.gameObject.transform.position = new Vector3(0f, 1f - p * i, -10f);
            this.gameObject.transform.localEulerAngles = new Vector3(-r * i, 0f, 0f);
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
    IEnumerator chg2()
    {
        float p = 0.4f, r = 2.2f;
        for (int i = 1; i <= 10; i++)
        {
            this.gameObject.transform.position = new Vector3(0f, -3f + p * i, -10f);
            this.gameObject.transform.localEulerAngles = new Vector3(-22f+ r * i, 0f, 0f);
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
