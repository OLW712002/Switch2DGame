using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinCollectSFX;
    bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isCollected)
        {
            isCollected = true;
            Destroy(gameObject);
            if (FindObjectOfType<GameSession>().CheckMusicOn()) AudioSource.PlayClipAtPoint(coinCollectSFX, gameObject.transform.position);
        }
    }
}
