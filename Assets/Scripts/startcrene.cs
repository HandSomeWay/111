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
