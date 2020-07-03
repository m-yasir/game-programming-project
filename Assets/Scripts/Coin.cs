using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Coin attributes")]
    public int point;

    [Header("Script References")]
    [SerializeField]
    protected ParticleSystem cParticleSystem;
    [SerializeField]
    protected SpriteRenderer spriteRender;
    [SerializeField]
    protected Collider2D cCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }

    void Collect()
    {
        GameManager.gm.addScore(point);
        cParticleSystem.Play();
        // Hiding coin sprite for the time being to let particles play and not destory it pre-maturely
        spriteRender.enabled = false;
        cCollider.enabled = false; // Disable collider so that nothing/player collides to it to simulate destroy while the particle system is playing.
        Destroy(gameObject, cParticleSystem.main.duration); // Destroy once particle system runs out.
        AudioManager.am.PlayCoinSound(); // Play collection sound
    }
}
