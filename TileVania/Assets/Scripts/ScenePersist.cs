using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    #region Variables

    private int startingSceneIndex;

    #endregion

    #region Private Methods

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        int numScenePersist = FindObjectsOfType<ScenePersist>().Length;
        if(numScenePersist > 1)
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
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != startingSceneIndex)
        {
            Debug.Log("48: Sceneersist Object Destroyed");
            Destroy(gameObject);
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Destroy this Gameobject (can be called from anywhere
    /// </summary>
    public void DestroyScenePersist()
    {
        Destroy(gameObject);
    }

    #endregion
}
