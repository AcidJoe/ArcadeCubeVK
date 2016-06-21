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
    public GameObject lightB, lightS, lightG;

    public GameObject silverButtons;
    public GameObject goldButtons;

    public bool isBronzeIn;
    public bool isSilverIn;
    public bool isGoldIn;


    void Start()
    {
        isBronzeIn = false;
        isSilverIn = false;
        isGoldIn = false;
        isGoldIn = false;

        lightB.SetActive(false);
        lightS.SetActive(false);
        lightG.SetActive(false);

        Tokens(false);
        currentPanel = mainPanel;
        backButton.SetActive(false);
        playPanel.SetActive(false);

        goldButtons.SetActive(false);

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

        if (isBronzeIn && !lightB.activeInHierarchy)
        {
            lightB.SetActive(true);
        }
        else if (!isBronzeIn)
        {
            lightB.SetActive(false);
        }
        else if(isSilverIn && !lightS.activeInHierarchy)
        {
            lightS.SetActive(true);
        }
        else if (!isSilverIn)
        {
            lightS.SetActive(false);
        }


        if(isGoldIn && !lightG.activeInHierarchy)
        {
            lightG.SetActive(true);
            silverButtons.SetActive(false);
            goldButtons.SetActive(true);
        }
        else if (!isGoldIn)
        {
            lightG.SetActive(false);
            silverButtons.SetActive(true);
            goldButtons.SetActive(false);
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
                    isBronzeIn = false;
                    isSilverIn = false;
                    isGoldIn = false;
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
        EventManager.sInsert += InsertS_Coin;
        EventManager.gInsert += InsertG_Coin;
    }

    void OnDisable()
    {
        EventManager.bInsert -= InsertB_Coin;
        EventManager.sInsert -= InsertS_Coin;
        EventManager.gInsert -= InsertG_Coin;
    }

    void InsertB_Coin()
    {
        Game.player.PayB_coin();
        isBronzeIn = true;
    }

    void InsertS_Coin()
    {
        Game.player.PayS_coin();
        isSilverIn = true;
    }

    void InsertG_Coin()
    {
        Game.player.PayG_coin();
        isGoldIn = true;
    }
}
