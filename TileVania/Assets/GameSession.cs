using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    #region Variables

    // Integers
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    // Text Objects
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    #endregion

    #region Private Methods

    /// <summary>
    /// When Gamesession is created
    /// </summary>
    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// Take a life when the player touches and enemy or hazard
    /// </summary>
    private void TakeLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// Reset the current game session
    /// </summary>
    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// 
    /// </summary>
    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// If the player touches an enemy or hazard, depending on lives remain
    /// either Take a life or reset the current game session
    /// </summary>
    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    #endregion
}
