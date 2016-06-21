using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TestSceneManager : MonoBehaviour
{
	void Start ()
    {
	
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMenu();
        }
	}

    void BackToMenu()
    {
        SceneManager.LoadScene(6);
    }

    public void LoadLevel()
    {
        if (Game.isReady)
        {
            StartCoroutine(setVars());
        }
    }

    public IEnumerator setVars()
    {
        Randomizer.SetToDiffMan();
        DifficultyManager.Settings();
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(Game.currentGame);
    }
}
