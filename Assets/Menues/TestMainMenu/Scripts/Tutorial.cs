using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Tutorial : MonoBehaviour
{
    public SocialManager sm;

    public Text greatings;
    public Text playerName;
    public Text checkText;
    public InputField input;
    public Button next;

    public string nameToCheck;

    public bool isCheked = false;
    public bool isValid = false;

	void Start ()
    {

	}
	
	void Update ()
    {
        greatings.text = "Приветсвую тебя, Новый Игрок !";
        nameToCheck = input.text;

        if (isValid)
            next.interactable = true;
        else
            next.interactable = false;

        if(nameToCheck == "")
        {
            playerName.text = Game.player._name;
            isValid = true;
        }
        else if(nameToCheck != "" && !isCheked)
        {
            playerName.text = Game.player._name;
        }
        else if(isValid && nameToCheck != "" && isCheked)
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

    public void Uncheck()
    {
        isCheked = false;
    }

    public void CheckName()
    {
        sm.startCheck(nameToCheck);
    }
}
