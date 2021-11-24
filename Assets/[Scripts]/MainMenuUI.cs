/* 
 * Full Name        : Abdulhakeem Idris
 * StudentID        : 101278361
 * Date Modified    : November 24, 2021
 * File             : MainMenuUI.cs
 * Description      : This scripts controlls the main menu UI buttons
 * Revision History : Version02
 */

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
