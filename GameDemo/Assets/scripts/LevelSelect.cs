using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
