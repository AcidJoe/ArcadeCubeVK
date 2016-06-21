using UnityEngine;
using System.Collections;

public class CoinInsert : MonoBehaviour
{
    public bool bReady;
    public bool sReady;
    public bool gReady;

    void Start ()
    {
        bReady = false;
        sReady = false;
        gReady = false;
	}
	
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.name)
        {
            case "Token-Bronze":
                bReady = true;
                break;
            case "Token-Silver":
                sReady = true;
                break;
            case "Token-Gold":
                gReady = true;
                break;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (!col.gameObject.GetComponent<Token>().isActive)
        {
            switch (col.gameObject.name)
            {
                case "Token-Bronze":
                    EventManager.OnInsert("b");
                    break;
                case "Token-Silver":
                    EventManager.OnInsert("s");
                    break;
                case "Token-Gold":
                    Debug.Log("Gold Inserted");
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        bReady = false;
        sReady = false;
        gReady = false;
    }
}
