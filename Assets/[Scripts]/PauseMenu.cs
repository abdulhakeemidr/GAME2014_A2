/* 
 * Full Name        : Abdulhakeem Idris
 * StudentID        : 101278361
 * Date Modified    : November 24, 2021
 * File             : PauseMenu.cs
 * Description      : This is the Pause Menu Script
 * Revision History : Version02
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Start()
    {
        //if(pauseMenuUI.activeInHierarchy)
        //{
        //    Resume();
        //}
    }

    private void Update()
    {
        // For Debugging Purposes
        // pauses game when I play with the pauseMenuUI switched on in editor
        if(pauseMenuUI.activeInHierarchy)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
