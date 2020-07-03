using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!GameManager.gm.isGameOver && collision.gameObject.CompareTag("Player"))
        {
            var death = collision.gameObject.GetComponent<PlayerDeath>();
            death.KillPlayer();
            var sr = collision.gameObject.GetComponent<SpriteRenderer>();
            sr.enabled = false;
            death.particle.Play();
            Destroy(collision.gameObject, death.particle.main.duration);
            GameManager.gm.EndGame();
        }
    }
}
