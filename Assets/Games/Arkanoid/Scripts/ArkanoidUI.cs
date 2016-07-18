using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArkanoidUI : MonoBehaviour
{
    ArcanoidManager gameManager;

    public Text score;
    public Text diff;

    public int curLives;

    public GameObject live1a, live1ia, live2a, live2ia, live3a, live3ia;

    public GameObject gameOverPanel;
    public Text winLose;
    public Text result;
    public GameObject pressKey;

    bool isReadyToExit;

    void Start ()
    {
        curLives = GameInfo.saveLives;
        pressKey.SetActive(false);
        winLose.gameObject.SetActive(false);
        result.gameObject.SetActive(false);
        isReadyToExit = false;
        gameOverPanel.SetActive(false);
        gameManager = FindObjectOfType<ArcanoidManager>();
	}
	
	void Update ()
    {
        score.text = currentScore(gameManager.score);
        diff.text = GameInfo.diffName;

        if(curLives != gameManager.lives)
        {
            if(gameManager.lives == 3)
            {
                live3a.SetActive(false);
                live3ia.SetActive(true);
            }
            else if (gameManager.lives == 2)
            {
                live2a.SetActive(false);
                live2ia.SetActive(true);
            }
            else if (gameManager.lives == 1)
            {
                live1a.SetActive(false);
                live1ia.SetActive(true);
            }
            else if(gameManager.lives == 0 && !gameOverPanel.activeInHierarchy)
            {
                GameOver();
                gameManager.GameOver();
            }

            curLives = gameManager.lives;
        }

        if (isReadyToExit)
        {
            if (Input.anyKeyDown)
            {
                EventManager.OnMenuBack();
            }
        }
    }

    void GameOver()
    {
        result.text = score.text;
        gameOverPanel.SetActive(true);
        StartCoroutine(delayText());
        StartCoroutine(waitSomeTime());
    }
    IEnumerator delayText()
    {
        yield return new WaitForSeconds(0.6f);
        winLose.gameObject.SetActive(true);
        result.gameObject.SetActive(true);
    }

    IEnumerator waitSomeTime()
    {
        yield return new WaitForSeconds(2);
        pressKey.SetActive(true);
        isReadyToExit = true;
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
