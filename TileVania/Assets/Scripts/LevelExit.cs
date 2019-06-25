using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    #region Variables

    [SerializeField] float LevelExitSlowMoFactor = 0.2f;
    [SerializeField] float LevelLoadDelay = 3f;

    #endregion

    #region Private Methods

    /// <summary>
    /// If the player touches the exit sign
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Load next level
        StartCoroutine(LoadNextLevel());
    }

    /// <summary>
    /// Load the next level
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadNextLevel()
    {
        // Set scale for the passing time to LevelExitSlowMoFactor
        Time.timeScale = LevelExitSlowMoFactor;

        // Wait Level load delay
        yield return new WaitForSecondsRealtime(LevelLoadDelay);

        // Reset the timescale
        Time.timeScale = 1f;

        // Get the current scene index number
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Destoy the Current Scenepersist object so it does not delete the ScenePersist Object in the next level
        FindObjectOfType<ScenePersist>().DestroyScenePersist();

        // Load the next scene after the current scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    #endregion
}