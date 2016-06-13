using UnityEngine;
using System.Collections;

public class Token : MonoBehaviour
{
    public TestMainMenu menu;

    public Vector3 origin;

    void Awake()
    {
        menu = FindObjectOfType<TestMainMenu>();
        origin = transform.position;
    }

    void OnMouseDown()
    {
        menu.currentToken = gameObject;
    }

    void OnMouseDrag()
    {
        transform.position = Input.mousePosition;
    }

    void OnMouseUp()
    {
        transform.position = origin;
        menu.currentToken = null;
    }
}
