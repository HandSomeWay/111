using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour
{
    static public bool ModeX;
    private void Start()
    {
        ModeX = true;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("GameMode Changed!");
            ModeX = !ModeX;
        }
    }
}
