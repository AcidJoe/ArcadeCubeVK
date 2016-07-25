using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SnakeUI : MonoBehaviour
{
    SnakeManager gameManager;
    SocialManager sm;
    SnakeSound sound;

    public Text score;
    public Text diff;

    public GameObject gameOverPanel;
    public Text winLose;
    public Text result;
    public GameObject pressKey;

    bool isReadyToExit;

    void Start ()
    {
        pressKey.SetActive(false);
        winLose.gameObject.SetActive(false);
        result.gameObject.SetActive(false);
        isReadyToExit = false;
        gameOverPanel.SetActive(false);
        gameManager = FindObjectOfType<SnakeManager>();
        sm = FindObjectOfType<SocialManager>();
        sound = FindObjectOfType<SnakeSound>();
    }
	
	void Update ()
    {
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

    public void GameOver()
    {
        sound.Lose();

        if (Game.player.rec_snk < gameManager.score)
        {
            sm._setRecord(gameManager.score);
        }
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
