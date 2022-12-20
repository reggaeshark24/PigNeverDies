using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // singleton instance

    public AudioSource musicSource; // audio source for background music
    public AudioSource sfxSource; // audio source for sound effects

    public AudioClip jumpSfx; // sound effect for jumping
    public AudioClip coinSfx; // sound effect for collecting coins
    public AudioClip deathSfx; // sound effect for death

    // Awake is called before Start
    void Awake()
    {
        // create singleton instance
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // play the jump sound effect
    public void PlayJumpSfx()
    {
        sfxSource.PlayOneShot(jumpSfx);
    }

    // play the coin sound effect
    public void PlayCoinSfx()
    {
        sfxSource.PlayOneShot(coinSfx);
    }

    // play the death sound effect
    public void PlayDeathSfx()
    {
        sfxSource.PlayOneShot(deathSfx);
    }
}