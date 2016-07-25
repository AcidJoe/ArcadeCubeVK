using UnityEngine;
using System.Collections;

public class ArcanoidSounds : MonoBehaviour
{
    public AudioSource Sound;

    public AudioClip bounce;
    public AudioClip _start;
    public AudioClip lose;
    public AudioClip gameOver;

    public void Bounce()
    {
        Sound.clip = bounce;
        Sound.Play();
    }

    public void StartGame()
    {
        Sound.clip = _start;
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
