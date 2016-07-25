using UnityEngine;
using System.Collections;

public class TetrisSound : MonoBehaviour
{
    public AudioSource Sound;

    public AudioClip rotate;
    public AudioClip drop;
    public AudioClip line;
    public AudioClip lose;

    public void Rot()
    {
        Sound.clip = rotate;
        Sound.Play();
    }
    
    public void Drop()
    {
        Sound.clip = drop;
        Sound.Play();
    }

    public void Line()
    {
        Sound.clip = line;
        Sound.Play();
    }

    public void Lose()
    {
        Sound.clip = lose;
        Sound.Play();
    }
}
