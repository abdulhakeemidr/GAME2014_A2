/* 
 * Full Name        : Abdulhakeem Idris
 * StudentID        : 101278361
 * Date Modified    : November 24, 2021
 * File             : UIBehaviour.cs
 * Description      : This script controls the button prefabs
 * Revision History : Version02
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIBehaviour : MonoBehaviour
{
    private int nextSceneIndex;
    private int previousSceneIndex;

    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
    }

    public void OnNextButtonPressed()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }

    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

}
