using UnityEngine;
using System.Collections;

public class TestIntro : MonoBehaviour
{
    public void TestProfile()
    {
        Game.player = new Profile("Тестер");
    }
}
