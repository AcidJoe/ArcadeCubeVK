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
        SceneManager.LoadScene(0);
    }
}
