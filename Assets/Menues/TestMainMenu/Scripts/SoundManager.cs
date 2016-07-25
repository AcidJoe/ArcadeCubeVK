using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource Sounds;

    public AudioClip CoinsInsert;
    public AudioClip MechButton;
    public AudioClip TakeCoin;
    public AudioClip UIButton;

	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    void OnEnable()
    {
        EventManager.bInsert += _DropCoin;
        EventManager.sInsert += _DropCoin;
        EventManager.gInsert += _DropCoin;
    }

    void OnDisable()
    {
        EventManager.bInsert -= _DropCoin;
        EventManager.sInsert -= _DropCoin;
        EventManager.gInsert -= _DropCoin;
    }

    void _DropCoin()
    {
        Sounds.clip = CoinsInsert;
        Sounds.Play();
    }

    public void ButtonSound()
    {
        Sounds.clip = MechButton;
        Sounds.Play();
    }

    public void CoinTake()
    {
        Sounds.clip = TakeCoin;
        Sounds.Play();
    }

    public void UIButton_sound()
    {
        Sounds.clip = UIButton;
        Sounds.Play();
    }
}
