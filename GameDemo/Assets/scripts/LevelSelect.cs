using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public void LevelAi()
    {
        SceneManager.LoadScene("Ai");
        Time.timeScale = 1;
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1;
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
