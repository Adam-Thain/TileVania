using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    #region Variables

    [SerializeField] int pointsForCoinPickup = 100;

    [SerializeField] float soundVol = 0.5f;

    [SerializeField] AudioClip coinPickUpSFX;

    GameObject audioListener;

    #endregion

    #region Private Methods

    /// <summary>
    /// If the player touches the coin
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            ProcessCoinPickup();
        }
    }

    /// <summary>
    /// Play coin sound, add points to score and then destroy the coin
    /// </summary>
    private void ProcessCoinPickup()
    {
        FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
        GameObject audioListener = GameObject.FindWithTag("AudioListener");
        AudioSource.PlayClipAtPoint(coinPickUpSFX, audioListener.transform.position, soundVol);
        Destroy(gameObject);
    }

    #endregion
}
