using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TetrisUI : MonoBehaviour
{
    TetrisManager gameManager;

    public Text score;
    public Text diff;

    public GameObject gameOverPanel;
    public Text winLose;
    public Text result;
    public GameObject pressKey;

    public Spawner_Tetris spawner;

    public GameObject[] nextShapes;

    bool isReadyToExit;

    void Start()
    {
        pressKey.SetActive(false);
        winLose.gameObject.SetActive(false);
        result.gameObject.SetActive(false);
        isReadyToExit = false;
        gameOverPanel.SetActive(false);
        gameManager = FindObjectOfType<TetrisManager>();
        spawner = FindObjectOfType<Spawner_Tetris>();
    }

    void Update()
    {
        CheckNext();

        score.text = currentScore(gameManager.score);
        diff.text = GameInfo.diffName;

        if (isReadyToExit)
        {
            if (Input.anyKeyDown)
            {
                EventManager.OnMenuBack();
            }
        }
    }

    void CheckNext()
    {
        for(int i = 0; i < 7; i++)
        {
            if(i == spawner.next)
            {
                nextShapes[i].SetActive(true);
                ColorElement[] ce = nextShapes[i].GetComponentsInChildren<ColorElement>();
                foreach(ColorElement c in ce)
                {
                    c.isPainted = false;
                    c.Repaint();
                }
            }
            else
            {
                nextShapes[i].SetActive(false);
            }
        }
    }

    void OnEnable()
    {
        TetrisEvents.gameOver += GameOver;
    }

    void OnDisable()
    {
        TetrisEvents.gameOver -= GameOver;
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
        if (i <= 9)
        {
            return "000" + i.ToString();
        }

        else if (i > 9 && i <= 99)
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
