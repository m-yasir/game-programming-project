using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Coin attributes")]
    public int point;

    [Header("Script References")]
    public ParticleSystem particleSystem;
    public SpriteRenderer renderer;
    public Collider2D collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collect();
        }
    }

    void collect()
    {
        GameManager.gm.addScore(point);
        particleSystem.Play();
        // Hiding coin sprite for the time being to let particles play and not destory it pre-maturely
        renderer.enabled = false;
        collider.enabled = false; // Disable collider so that nothing/player collides to it to simulate destroy while the particle system is playing.
        Destroy(gameObject, particleSystem.main.duration); // Destroy once particle system runs out.
        AudioManager.am.PlayCoinSound(); // Play collection sound
    }
}
