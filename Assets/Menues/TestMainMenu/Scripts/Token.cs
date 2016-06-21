using UnityEngine;
using System.Collections;

public class Token : MonoBehaviour
{
    public TestMainMenu menu;

    public Vector3 origin;
    public Vector3 mousePos;

    public bool isActive;
    bool isInPlace;

    void Start()
    {
        menu = FindObjectOfType<TestMainMenu>();
        origin = transform.position;
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(!isActive && !isInPlace)
        {
            transform.Translate((origin - transform.position).normalized * Time.deltaTime * 25);

            if (Mathf.Abs(origin.x - transform.position.x) < 0.5f && Mathf.Abs(origin.y - transform.position.y) < 0.5f)
            {
                transform.position = origin;
                isInPlace = true;
            }
        }
    }

    void OnMouseDown()
    {
        menu.currentToken = gameObject;
        isActive = true;
    }

    void OnMouseDrag()
    {
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        isInPlace = false;
    }

    void OnMouseUp()
    {
        menu.currentToken = null;
        isActive = false;
    }

    void OnEnable()
    {
        EventManager.bInsert += Back;
        EventManager.sInsert += Back;
    }

    void OnDisable()
    {
        EventManager.bInsert -= Back;
        EventManager.sInsert -= Back;
    }

    void Back()
    {
        transform.position = origin;
    }
}
