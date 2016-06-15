using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public static TestMainMenu manager;
    public delegate void CoinInsert();

    public static event CoinInsert bInsert;
    public static event CoinInsert sInsert;
    public static event CoinInsert gInsert;

    void Start ()
    {
        manager = FindObjectOfType<TestMainMenu>();
	}
	
	void Update ()
    {
	
	}

    public static void OnInsert(string type)
    {
        switch (type)
        {
            case "b":
                if (!manager.isBronzeIn)
                {
                    bInsert();
                }
                break;
            case "s":
                break;
            case "g":
                break;
        }
    }
}
