using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArkanoidUI : MonoBehaviour
{
    ArcanoidManager gameManager;

    public Text score;

    public RawImage live1a, live1ia, live2a, live2ia, live3a, live3ia;

	void Start ()
    {
        gameManager = FindObjectOfType<ArcanoidManager>();
	}
	
	void Update ()
    {
        score.text = currentScore(gameManager.score);
	}

    public string currentScore(int i)
    {
        if(i <= 9)
        {
            return "000" + i.ToString();
        }

        else if(i > 9 && i <= 99)
        {
            return "00" + i.ToString();
        }

        else if (i > 99 && i <= 999)
        {
            return "0" + i.ToString();
        }

        return i.ToString();
    }
}
