using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour
{
    static public bool ModeX;//游戏模式
    static public bool GameOver;//游戏失败
    static public bool Victory;//游戏胜利
    private int i;
    public Light SunLight;
    public GameObject PlayerA;
    public GameObject PlayerB;
    public Transform PA;
    public Transform PB;
    public Transform PAT;
    public Transform PBT;
    
    private void Start()
    {
        ModeX = true;
        GameOver = false;
        Victory = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("GameMode Changed!");
            ModeX = !ModeX;
            StartCoroutine(LightChg());
        }
        if (ModeX) //模式转换时，另一维度的角色固定且透明化
        {
            PAT.parent = PA;
            PBT.parent = null;
            PlayerB.active = false;
            PlayerA.active = true;
        }
        else
        {
            PAT.parent = null;
            PBT.parent = PB;
            PlayerA.active = false;
            PlayerB.active = true;
        }
    }
    IEnumerator LightChg()
    {
        for (int j = 1; j <= 60; j++)
        {
            SunLight.transform.Rotate(3f, 0, 0,Space.World);
            //System.Threading.Thread.Sleep(10);
            yield return new WaitForSeconds(0.01f);
        }
        yield return 0;
    }
}
