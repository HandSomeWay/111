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
    public void start()//��ʼ��Ϸ
    {
        Debug.Log("start");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exit()//�˳�
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    
    public void proteam()//�������Ŷ�
    {
        obj.SetActive(true);
        obj1.SetActive(false);
    }
    public void back()//�ر������Ŷ�
    {
        obj.SetActive(false);
        obj1.SetActive(true);
    }
}
