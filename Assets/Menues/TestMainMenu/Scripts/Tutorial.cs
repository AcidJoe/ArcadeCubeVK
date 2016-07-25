using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Tutorial : MonoBehaviour
{
    public SocialManager sm;

    public GameObject first;
    public GameObject second;

    public GameObject[] panels;
    public int currentActive = 0;

    public Button next2;

    public Text greatings;
    public Text playerName;
    public Text checkText;
    public InputField input;
    public Button next;

    public Text nameAdded;

    public string nameToCheck;

    public bool isCheked = false;
    public bool isValid = false;

	void Start ()
    {
        first.SetActive(true);
        second.SetActive(false);
	}
	
	void Update ()
    {
        greatings.text = "Приветсвую тебя, Новый Игрок !";
        nameToCheck = input.text;
        nameAdded.text = "Отлично, " + Game.player._name+ " !";

        if (first.activeInHierarchy)
        {
            First();
        }
        else
        {
            Second();
        }
    }

    public void First()
    {
        if (isValid)
            next.interactable = true;
        else
            next.interactable = false;

        if (nameToCheck == "")
        {
            playerName.text = Game.player._name;
            isValid = true;
        }
        else if (nameToCheck != "" && !isCheked)
        {
            playerName.text = Game.player._name;
        }
        else if (isValid && nameToCheck != "" && isCheked)
        {
            checkText.color = Color.green;
            checkText.text = "Свободно";
            playerName.text = nameToCheck;
        }
        else if (!isValid && nameToCheck != "" && isCheked)
        {
            checkText.color = Color.red;
            checkText.text = "Занято";
        }
    }

    public void Second()
    {
        if(currentActive != 5)
        {
            ActivatePanel(currentActive);
        }
        else
        {
            sm.endTutorial();
        }
    }

    public IEnumerator buttonDelay()
    {
        next2.interactable = false;
        yield return new WaitForSeconds(2.5f);
        next2.interactable = true;
    }

    public void NextPanel()
    {
        currentActive++;
        StartCoroutine(buttonDelay());
    }

    public void ActivatePanel(int number)
    {
        for (int i = 0; i <= panels.Length; i++)
        {
            if (i == number)
                panels[i].SetActive(true);
            else
                panels[i].SetActive(false);
        }
    }

    public void Uncheck()
    {
        isCheked = false;
    }

    public void CheckName()
    {
        sm.startCheck(nameToCheck);
    }

    public void ToTutorial()
    {
        Game.player._name = playerName.text;
        sm._setName();
        first.SetActive(false);
        second.SetActive(true);
        StartCoroutine(buttonDelay());
    }
}
