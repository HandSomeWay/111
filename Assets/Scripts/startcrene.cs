using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startcrene : MonoBehaviour
{
    public GameObject obj;
    public GameObject obj1;
    public GameObject map;
    public void close()
    {
        map.SetActive(false);
    }
    public void openmap()
    {
        map.SetActive(true);
    }
    public void load1()
    {
        SceneManager.LoadScene(3);
    }
    public void load2()
    {
        SceneManager.LoadScene(4);
    }
    public void load3()
    {
        SceneManager.LoadScene(5);
    }
    public void start()//开始游戏
    {
        Debug.Log("start");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exit()//退出
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    
    public void proteam()//打开制作团队
    {
        obj.SetActive(true);
        obj1.SetActive(false);
    }
    public void back()//关闭制作团队
    {
        obj.SetActive(false);
        obj1.SetActive(true);
    }
}
