using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestMainMenu : MonoBehaviour
{
    public Text _name;
    public Text lvl;
    public Text exp;

    public Text stoken;
    public Text gtoken;

    public Image photo;

    public Image progressBar;

    public Sprite sprite;

    public GameObject mainPanel;
    public GameObject playPanel;
    public GameObject aboutPanel;
    public GameObject recordPanel;
    public GameObject friendPanel;
    public GameObject storePanel;

    public GameObject currentPanel;
    public GameObject backButton;

    public GameObject currentToken;

    public int currentAbout = 0;
    public string currentAboutName = "Управление";
    public GameObject[] aboutSlides;
    public Text aboutPanelName;

    public Text[] recordNames;
    public Text[] recordValues;
    public int currentRecord = 0;
    public string currentRecName = "Опыт";
    public Text records_name;
    public Text playerRecord;
    public static bool isSet;

    public Text friendsCount;
 
    public GameObject tokenbutton_b, tokenbutton_s, tokenbutton_g;
    public GameObject lightB, lightS, lightG;

    public GameObject silverButtons;
    public GameObject goldButtons;

    public bool isBronzeIn;
    public bool isSilverIn;
    public bool isGoldIn;

    public bool isTutorialActive = false;

    public SocialManager sm;

    void Start()
    {
        GameInfo.difficulty = 0;
        EventManager.OnGameEnd();
        GameInfo.isPlay = false;

        sm = FindObjectOfType<SocialManager>();

        GameInfo.saveResult = 0;
        GameInfo.saveLives = 4;
        GameInfo.extraRound = 0;

        isSet = false;

        isBronzeIn = false;
        isSilverIn = false;
        isGoldIn = false;

        lightB.SetActive(false);
        lightS.SetActive(false);
        lightG.SetActive(false);

        Tokens(false);
        currentPanel = mainPanel;
        backButton.SetActive(false);
        playPanel.SetActive(false);
        aboutPanel.SetActive(false);
        recordPanel.SetActive(false);
        friendPanel.SetActive(false);
        storePanel.SetActive(false);

        goldButtons.SetActive(false);

        if (Game.player == null)
        {
            Game.player = new Profile("Тестер");
        }

        _name.text = Game.player._name;
        sm.records(0);
        Application.ExternalCall("CheckFriends");
    }

    void Update()
    {
        if(Game.player.isEndTutorial != 1)
        {
            isTutorialActive = true;
        }

        lvl.text = "Уровень " + Game.player.lvl.ToString();
        exp.text = Game.player.exp.ToString() + "/" + Game.player.exp_to_next.ToString();
        stoken.text = Game.player.s_tokens.ToString();
        gtoken.text = Game.player.g_tokens.ToString();
        progressBar.fillAmount = Game.player.exp / (float)Game.player.exp_to_next;
        photo.sprite = sprite;

        ChekTokens();

        if (aboutPanel.activeInHierarchy)
        {
            About();
        }
        else if (recordPanel.activeInHierarchy)
        {
            Record();
        }
        else if (friendPanel.activeInHierarchy)
        {
            friendsCount.text = Game.player.friends.Count.ToString();
        }

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

    public void SetFriends(string s)
    {
        char sep = ',';
        string[] friends = s.Split(sep);

        Game.player.friends.Clear();

        foreach(string str in friends)
        {
            Game.player.friends.Add(int.Parse(str));
        }
    }

    public void Invite()
    {
        Application.ExternalCall("Invite");
    }

    void ChekTokens()
    {
        if(Game.player.s_tokens <= 0)
        {
            tokenbutton_s.SetActive(false);
        }
        else if(Game.player.g_tokens <= 0)
        {
            tokenbutton_g.SetActive(false);
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
            case 2:
                if (!aboutPanel.activeInHierarchy)
                {
                    currentPanel.SetActive(false);
                    aboutPanel.SetActive(true);
                    currentPanel = aboutPanel;
                    backButton.SetActive(true);
                    Tokens(false);
                    isBronzeIn = false;
                    isSilverIn = false;
                    isGoldIn = false;
                }
                break;
            case 3:
                if (!recordPanel.activeInHierarchy)
                {
                    currentPanel.SetActive(false);
                    recordPanel.SetActive(true);
                    currentPanel = recordPanel;
                    backButton.SetActive(true);
                    Tokens(false);
                    isBronzeIn = false;
                    isSilverIn = false;
                    isGoldIn = false;
                    changeRecord(0);
                }
                break;
            case 4:
                if (!friendPanel.activeInHierarchy)
                {
                    currentPanel.SetActive(false);
                    friendPanel.SetActive(true);
                    currentPanel = friendPanel;
                    backButton.SetActive(true);
                    Tokens(false);
                    isBronzeIn = false;
                    isSilverIn = false;
                    isGoldIn = false;
                    Application.ExternalCall("CheckFriends");
                }
                break;
            case 5:
                if (!storePanel.activeInHierarchy)
                {
                    currentPanel.SetActive(false);
                    storePanel.SetActive(true);
                    currentPanel = storePanel;
                    backButton.SetActive(true);
                    Tokens(false);
                    isBronzeIn = false;
                    isSilverIn = false;
                    isGoldIn = false;
                }
                break;
        }
    }

    public void Order(int i)
    {
        Application.ExternalCall("order", i);
    }

    void About()
    {
        aboutPanelName.text = currentAboutName;
    }

    void Record()
    {
        records_name.text = currentRecName;

        if (!isSet)
        {
            for(int i = 0; i <= 9; i++)
            {
                recordNames[i].text = GameInfo.recordNames[i];
                recordValues[i].text = GameInfo.recordValues[i];
            }

            isSet = true;
        }
    }

    public void changeSlide(int i)
    {
        currentAbout += i;

        if (currentAbout > 1)
        {
            currentAbout = 0;
        }
        else if (currentAbout < 0)
        {
            currentAbout = 1;
        }

        switch (currentAbout)
        {
            case 0:
                currentAboutName = "Управление";
                break;
            case 1:
                currentAboutName = "Создатели";
                break;
        }

        for (int n = 0; n <= aboutSlides.Length; n++)
        {
            if(n == currentAbout)
            {
                aboutSlides[n].SetActive(true);
            }
            else
            {
                aboutSlides[n].SetActive(false);
            }
        }
    }

    public void changeRecord(int i)
    {
        currentRecord += i;

        if (currentRecord == 5)
        {
            currentRecord = 0;
        }
        else if (currentRecord == -1)
        {
            currentRecord = 4;
        }

        switch (currentRecord)
        {
            case 0:
                playerRecord.text = Game.player.exp_all.ToString();
                currentRecName = "Опыт";
                break;
            case 1:
                playerRecord.text = Game.player.rec_ark.ToString();
                currentRecName = "Арканоид";
                break;
            case 2:
                playerRecord.text = Game.player.rec_ast.ToString();
                currentRecName = "Астероиды";
                break;
            case 3:
                playerRecord.text = Game.player.rec_snk.ToString();
                currentRecName = "Змейка";
                break;
            case 4:
                playerRecord.text = Game.player.rec_tet.ToString();
                currentRecName = "Тетрис";
                break;
        }

        sm.records(currentRecord);
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
