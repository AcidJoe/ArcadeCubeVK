using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestMenu : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject diffPanel;
    public Text version;

    int gameID;
    int diffID;

    void Start ()
    {
        version.text = GameInfo.currentVersion;
        gameID = 0;
        diffID = 0;

        gamePanel.SetActive(true);
        diffPanel.SetActive(false);
	}
	
	void Update ()
    {
	    if(gamePanel.activeInHierarchy && gameID != 0)
        {
            gamePanel.SetActive(false);
            diffPanel.SetActive(true);
        }
        else if(diffPanel.activeInHierarchy && diffID != 0)
        {
            LoadGame(gameID, diffID);
        }
	}

    public void SetGame(int i)
    {
        gameID = i;
    }

    public void SetDiff(int i)
    {
        diffID = i;
    }

    void LoadGame(int game, int diff)
    {
        GameInfo.difficulty = diff;

        SceneManager.LoadScene(game);
    }
}
