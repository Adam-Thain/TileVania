using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    #region public methods

    /// <summary>
    /// Go to the first level
    /// </summary>
    public void StartFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Go to the Main Menu
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    #endregion
}
