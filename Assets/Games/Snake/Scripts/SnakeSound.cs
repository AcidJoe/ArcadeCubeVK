using UnityEngine;
using System.Collections;

public class SnakeSound : MonoBehaviour
{
    public AudioSource Sound;

    public AudioClip take;
    public AudioClip lose;

    public void Take()
    {
        Sound.clip = take;
        Sound.Play();
    }

    public void Lose()
    {
        Sound.clip = lose;
        Sound.Play();
    }
}
