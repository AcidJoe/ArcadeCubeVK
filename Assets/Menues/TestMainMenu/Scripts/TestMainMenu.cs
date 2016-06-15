using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestMainMenu : MonoBehaviour
{
    public Text _name;
    public Text lvl;
    public Text exp;

    public Text btoken;
    public Text stoken;
    public Text gtoken;

    public Image photo;

    public Image progressBar;

    public Sprite sprite;

    public GameObject mainPanel;
    public GameObject playPanel;

    public GameObject currentPanel;
    public GameObject backButton;

    public GameObject currentToken;

    public GameObject tokenbutton_b, tokenbutton_s, tokenbutton_g;

    public bool isBronzeIn;
    public bool isSilverIn;
    public bool isGoldIn;


    void Start()
    {
        isBronzeIn = false;
        isSilverIn = false;
        isGoldIn = false;

        Tokens(false);
        currentPanel = mainPanel;
        backButton.SetActive(false);
        playPanel.SetActive(false);

        if (Game.player == null)
        {
            Game.player = new Profile("Тестер");
        }

        _name.text = Game.player.name;
    }

    void Update()
    {
        lvl.text = "Уровень " + Game.player.lvl.ToString();
        exp.text = ExpManager.Calculate(Game.player.exp).ToString() + "/" + ExpManager.expToNext;
        btoken.text = Game.player.b_tokens.ToString();
        stoken.text = Game.player.s_tokens.ToString();
        gtoken.text = Game.player.g_tokens.ToString();
        progressBar.fillAmount = (float)ExpManager.Calculate(Game.player.exp) / (float)ExpManager.expToNext;
        photo.sprite = sprite;

        if(currentToken && Input.GetMouseButtonUp(0))
        {
            Destroy(currentToken);
        }
    }

    public void ChangePanels(int i)
    {
        switch (i)
        {
            case 0:
                if (!mainPanel.activeInHierarchy)
                {
                    currentPanel.SetActive(false);
                    mainPanel.SetActive(true);
                    currentPanel = mainPanel;
                    backButton.SetActive(false);
                    Tokens(false);
                }
                break;
            case 1:
                if (!playPanel.activeInHierarchy)
                {
                    currentPanel.SetActive(false);
                    playPanel.SetActive(true);
                    currentPanel = playPanel;
                    backButton.SetActive(true);
                    Tokens(true);
                }
                break;
        }
    }

    void Tokens(bool activate)
    {
        if (activate)
        {
            tokenbutton_b.SetActive(true);
            tokenbutton_s.SetActive(true);
            tokenbutton_g.SetActive(true);
        }
        else if (!activate)
        {
            tokenbutton_b.SetActive(false);
            tokenbutton_s.SetActive(false);
            tokenbutton_g.SetActive(false);
        }
    }

    void OnEnable()
    {
        EventManager.bInsert += InsertB_Coin;
    }

    void OnDisable()
    {
        EventManager.bInsert -= InsertB_Coin;
    }

    void InsertB_Coin()
    {
        Game.player.PayB_coin();
        isBronzeIn = true;
    }
}
