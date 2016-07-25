using UnityEngine;
using System.Collections;

public class AstroSounds : MonoBehaviour
{
    public AudioSource Sound;

    public AudioClip fire;
    public AudioClip destroy;
    public AudioClip lose;
    public AudioClip gameOver;

    public void Fire()
    {
        Sound.clip = fire;
        Sound.Play();
    }

    public void _Destroy()
    {
        Sound.clip = destroy;
        Sound.Play();
    }

    public void Lose()
    {
        Sound.clip = lose;
        Sound.Play();
    }

    public void GameOver()
    {
        Sound.clip = gameOver;
        Sound.Play();
    }
}
