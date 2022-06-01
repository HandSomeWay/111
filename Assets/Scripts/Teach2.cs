using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teach2 : MonoBehaviour
{
    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            UI.SetActive(false);
        if (!Cube1.active && !Cube2.active) ModeController.Victory = true;   
    }
}
