using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            ingameMenu.SetActive(true);
        }
    }

    public GameObject ingameMenu;
    
    public void OnPause()
    {
        Time.timeScale = 0;
        ingameMenu.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        ingameMenu.SetActive(false);
    }

    public void Home()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(0);
    }
}
