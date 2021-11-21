using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
