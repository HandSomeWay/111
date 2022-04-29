using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startcrene : MonoBehaviour
{
    public GameObject obj;

    public void start()//开始游戏
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exit()//退出
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    
    public void proteam()//打开制作团队
    {
        obj.SetActive(true);
    }
    public void back()//关闭制作团队
    {
        obj.SetActive(false);
    }
}
