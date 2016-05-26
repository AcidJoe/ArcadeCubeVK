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
        switch (gameID)
        {
            case 1:
                DifficultyManager.SetGame(DifficultyManager.Game.Arkanoid);
                break;
            case 2:
                DifficultyManager.SetGame(DifficultyManager.Game.Asteroids);
                break;
            case 3:
                DifficultyManager.SetGame(DifficultyManager.Game.Pong);
                break;
            case 4:
                DifficultyManager.SetGame(DifficultyManager.Game.Snake);
                break;
            case 5:
                DifficultyManager.SetGame(DifficultyManager.Game.Tetris);
                break;
        }
    }

    public void SetDiff(int i)
    {
        diffID = i;
    }

    void LoadGame(int game, int diff)
    {
        GameInfo.difficulty = diff;
        DifficultyManager.Settings();

        if (diff == 1)
        {
            GameInfo.diffName = "Очень легко";
        }
        else if(diff == 2)
        {
            GameInfo.diffName = "Легко";
        }
        else if (diff == 3)
        {
            GameInfo.diffName = "Средне";
        }
        else if (diff == 4)
        {
            GameInfo.diffName = "Сложно";
        }
        else if (diff == 5)
        {
            GameInfo.diffName = "Очень сложно";
        }
        else if (diff == 6)
        {
            GameInfo.diffName = "Хардкор";
        }

        SceneManager.LoadScene(game);
    }
}
