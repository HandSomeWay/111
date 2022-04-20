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
            this.gameObject.transform.position = new Vector3(10f, 0.5f, -1f);
            this.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

        }
        else
        {
            this.gameObject.transform.position = new Vector3(10f, -1, -1f);
            this.gameObject.transform.localEulerAngles = new Vector3(-25f, 0f, 0f);
        }
    }
}
