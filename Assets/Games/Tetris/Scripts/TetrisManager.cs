using UnityEngine;
using System.Collections;

public class TetrisManager : MonoBehaviour
{
    public int score;
    public int lineCount;

    public ColorElement[] colorElements;

	void Start ()
    {
        score = 0;
        lineCount = 0;
	}
	
	void Update ()
    {
        colorElements = FindObjectsOfType<ColorElement>();

	    if(lineCount >= 20)
        {
            LevelUp();
        }
	}

    void LevelUp()
    {
        if (GameInfo.difficulty < 6)
        {
            EventManager.OnGameEnd();
            GameInfo.difficulty++;
            DifficultyManager.Settings();
            DifficultyManager.SetDiffName();
            EventManager.OnStartGame();

            foreach (ColorElement c in colorElements)
            {
                c.isPainted = false;
                c.Repaint();
            }
        }

        else
        {
            EventManager.OnGameEnd();
            GameInfo.extraRound++;
            DifficultyManager.ExtraSettings();
            EventManager.OnStartGame();
        }

        lineCount = 0;
    }
}
