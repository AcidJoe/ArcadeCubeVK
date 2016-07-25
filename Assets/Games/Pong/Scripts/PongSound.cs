using UnityEngine;
using System.Collections;

public class PongSound : MonoBehaviour
{
    public AudioSource Sound;

    public AudioClip bounce;
    public AudioClip goal;
    public AudioClip lose;
    public AudioClip win;
    public AudioClip lost;

    public void Bounce()
    {
        Sound.clip = bounce;
        Sound.Play();
    }

    public void Goal(int i)
    {
        switch (i)
        {
            case 0:
                Sound.clip = goal;
                Sound.Play();
                break;
            case 1:
                Sound.clip = lose;
                Sound.Play();
                break;
        }
    }

    public void Win()
    {
        Sound.clip = win;
        Sound.Play();
    }

    public void Lose()
    {
        Sound.clip = lost;
        Sound.Play();
    }
}
