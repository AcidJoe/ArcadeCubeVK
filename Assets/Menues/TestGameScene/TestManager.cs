using UnityEngine;
using System.Collections;

public class TestManager : MonoBehaviour
{
    [SerializeField]
    GameObject screen;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckButton();
        }

        if (screen.activeInHierarchy)
        {
            Time.timeScale *= 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void CheckButton()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            if (hit.collider.gameObject.tag == "Ball")
            {
                if (screen.activeInHierarchy)
                {
                    screen.SetActive(false);
                }
                else
                {
                    screen.SetActive(true);
                }
            }
    }
}
