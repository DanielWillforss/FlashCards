using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneHandeler
{
    public static void ChangeScene(string sceneName)
    {
        if(sceneName == "Exit")
        {
            Exit();
        } 
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public static void Exit()
    {
        Application.Quit();
    }
}
