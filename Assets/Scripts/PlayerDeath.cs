using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public AudioSource deathAudio;
    public ParticleSystem particle;

    public void KillPlayer()
    {
        deathAudio.PlayOneShot(deathAudio.clip);
    }
}
