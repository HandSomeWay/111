using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour
{
    static public bool ModeX;
    public GameObject PlayerA;
    public GameObject PlayerB;
    public Transform PA;
    public Transform PB;
    public Transform PAT;
    public Transform PBT;
    
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
        if (ModeX) 
        {
            PAT.parent = PA;
            PBT.parent = null;
            PlayerA.active = true; 
            PlayerB.active = false;
        }
        else
        {
            PAT.parent = null;
            PBT.parent = PB;
            PlayerA.active = false; 
            PlayerB.active = true;
        }
    }

}
