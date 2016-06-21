using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TestIntro : MonoBehaviour
{
    public void TestProfile()
    {
        Game.player = new Profile("Тестер");

        SceneManager.LoadScene(6);
    }
}
