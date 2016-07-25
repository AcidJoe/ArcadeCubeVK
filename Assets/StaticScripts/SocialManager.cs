using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class SocialManager: MonoBehaviour
{
    public Profile profile;
    public TestIntro ti;

    public int uid;
    public string photo;
    public string _name = "Default";

    public string _profile = "https://www.acidjoe.ru/Games/ACTest/PHP/profile.php";
    public string _update = "https://www.acidjoe.ru/Games/ACTest/PHP/update.php";
    public string _records = "https://www.acidjoe.ru/Games/ACTest/PHP/record.php";

    public bool isHaveName = false;
    public bool isHaveID = false;
    public bool isHavePhoto = false;

    void OnEnable()
    {
        EventManager.sInsert += InsertS_Coin;
        EventManager.gInsert += InsertG_Coin;
        EventManager.startGame += _start;
        EventManager.endGame += _end;
        EventManager.toMenu += _loadProfile;
    }

    void OnDisable()
    {
        EventManager.sInsert -= InsertS_Coin;
        EventManager.gInsert -= InsertG_Coin;
        EventManager.startGame -= _start;
        EventManager.endGame -= _end;
        EventManager.toMenu -= _loadProfile;
    }

    void InsertS_Coin()
    {
        StartCoroutine(PayCoin("silver"));
    }

    void InsertG_Coin()
    {
        StartCoroutine(PayCoin("gold"));
    }

    public void UpdateCoins()
    {
        StartCoroutine(PayCoin("update_gold"));
    }

    public void _setName()
    {
        StartCoroutine(setName());
    }

    public void records(int i)
    {
        StartCoroutine(getRecords(i));
    }

    public IEnumerator getRecords(int i)
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "getRecords");
        form.AddField("type", i);
        WWW www = new WWW(_records, form);
        yield return www;
        var _result = JSON.Parse(www.text);

        GameInfo.recordNames.Clear();
        GameInfo.recordValues.Clear();

        GameInfo.recordNames.Add(_result[0]["name"]);
        GameInfo.recordNames.Add(_result[1]["name"]);
        GameInfo.recordNames.Add(_result[2]["name"]);
        GameInfo.recordNames.Add(_result[3]["name"]);
        GameInfo.recordNames.Add(_result[4]["name"]);
        GameInfo.recordNames.Add(_result[5]["name"]);
        GameInfo.recordNames.Add(_result[6]["name"]);
        GameInfo.recordNames.Add(_result[7]["name"]);
        GameInfo.recordNames.Add(_result[8]["name"]);
        GameInfo.recordNames.Add(_result[9]["name"]);

        switch (i)
        {
            case 0:
                GameInfo.recordValues.Add(_result[0]["exp_all"]);
                GameInfo.recordValues.Add(_result[1]["exp_all"]);
                GameInfo.recordValues.Add(_result[2]["exp_all"]);
                GameInfo.recordValues.Add(_result[3]["exp_all"]);
                GameInfo.recordValues.Add(_result[4]["exp_all"]);
                GameInfo.recordValues.Add(_result[5]["exp_all"]);
                GameInfo.recordValues.Add(_result[6]["exp_all"]);
                GameInfo.recordValues.Add(_result[7]["exp_all"]);
                GameInfo.recordValues.Add(_result[8]["exp_all"]);
                GameInfo.recordValues.Add(_result[9]["exp_all"]);
                break;
            case 1:
                GameInfo.recordValues.Add(_result[0]["record_ark"]);
                GameInfo.recordValues.Add(_result[1]["record_ark"]);
                GameInfo.recordValues.Add(_result[2]["record_ark"]);
                GameInfo.recordValues.Add(_result[3]["record_ark"]);
                GameInfo.recordValues.Add(_result[4]["record_ark"]);
                GameInfo.recordValues.Add(_result[5]["record_ark"]);
                GameInfo.recordValues.Add(_result[6]["record_ark"]);
                GameInfo.recordValues.Add(_result[7]["record_ark"]);
                GameInfo.recordValues.Add(_result[8]["record_ark"]);
                GameInfo.recordValues.Add(_result[9]["record_ark"]);
                break;
            case 2:
                GameInfo.recordValues.Add(_result[0]["record_astr"]);
                GameInfo.recordValues.Add(_result[1]["record_astr"]);
                GameInfo.recordValues.Add(_result[2]["record_astr"]);
                GameInfo.recordValues.Add(_result[3]["record_astr"]);
                GameInfo.recordValues.Add(_result[4]["record_astr"]);
                GameInfo.recordValues.Add(_result[5]["record_astr"]);
                GameInfo.recordValues.Add(_result[6]["record_astr"]);
                GameInfo.recordValues.Add(_result[7]["record_astr"]);
                GameInfo.recordValues.Add(_result[8]["record_astr"]);
                GameInfo.recordValues.Add(_result[9]["record_astr"]);
                break;
            case 3:
                GameInfo.recordValues.Add(_result[0]["record_sn"]);
                GameInfo.recordValues.Add(_result[1]["record_sn"]);
                GameInfo.recordValues.Add(_result[2]["record_sn"]);
                GameInfo.recordValues.Add(_result[3]["record_sn"]);
                GameInfo.recordValues.Add(_result[4]["record_sn"]);
                GameInfo.recordValues.Add(_result[5]["record_sn"]);
                GameInfo.recordValues.Add(_result[6]["record_sn"]);
                GameInfo.recordValues.Add(_result[7]["record_sn"]);
                GameInfo.recordValues.Add(_result[8]["record_sn"]);
                GameInfo.recordValues.Add(_result[9]["record_sn"]);
                break;
            case 4:
                GameInfo.recordValues.Add(_result[0]["record_tet"]);
                GameInfo.recordValues.Add(_result[1]["record_tet"]);
                GameInfo.recordValues.Add(_result[2]["record_tet"]);
                GameInfo.recordValues.Add(_result[3]["record_tet"]);
                GameInfo.recordValues.Add(_result[4]["record_tet"]);
                GameInfo.recordValues.Add(_result[5]["record_tet"]);
                GameInfo.recordValues.Add(_result[6]["record_tet"]);
                GameInfo.recordValues.Add(_result[7]["record_tet"]);
                GameInfo.recordValues.Add(_result[8]["record_tet"]);
                GameInfo.recordValues.Add(_result[9]["record_tet"]);
                break;
        }

        TestMainMenu.isSet = false;
    }

    public IEnumerator setName()
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "setName");
        form.AddField("uid", Game.player.id);
        form.AddField("name", Game.player._name);
        WWW www = new WWW(_update, form);
        yield return www;
    }

    public IEnumerator endTuto()
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "endTuto");
        form.AddField("uid", Game.player.id);
        WWW www = new WWW(_update, form);
        yield return www;
        _loadProfile();
    }

    public IEnumerator GetProfile()
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "profile");
        form.AddField("uid", uid);
        WWW www = new WWW(_profile, form);
        yield return www;
        var _result = JSON.Parse(www.text);
        Game.player = new Profile(
            _result[0]["name"], 
            photo,
            uid,
            _result[0]["silver"].AsInt,
            _result[0]["gold"].AsInt,
            _result[0]["lvl"].AsInt,
            _result[0]["exp"].AsInt,
            _result[0]["exp_next"].AsInt,
            _result[0]["tutorial"].AsInt,
            _result[0]["exp_all"].AsInt,
            _result[0]["record_tet"].AsInt,
            _result[0]["record_astr"].AsInt,
            _result[0]["record_ark"].AsInt,
            _result[0]["record_sn"].AsInt
            );

        if(Game.player._name == "Игрок")
        {
            Game.player._name = _name;
        }


        if(Game.player.isEndTutorial == 1)
            SceneManager.LoadScene(6);
        else
            SceneManager.LoadScene(7);
    }

    public IEnumerator _Get_Profile()
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "profile");
        form.AddField("uid", Game.player.id);
        form.AddField("diff", GameInfo.difficulty);
        WWW www = new WWW(_profile, form);
        yield return www;
        var _result = JSON.Parse(www.text);
        Game.player = new Profile(
            _result[0]["name"],
            photo,
            Game.player.id,
            _result[0]["silver"].AsInt,
            _result[0]["gold"].AsInt,
            _result[0]["lvl"].AsInt,
            _result[0]["exp"].AsInt,
            _result[0]["exp_next"].AsInt,
            _result[0]["tutorial"].AsInt,
            _result[0]["exp_all"].AsInt,
            _result[0]["record_tet"].AsInt,
            _result[0]["record_astr"].AsInt,
            _result[0]["record_ark"].AsInt,
            _result[0]["record_sn"].AsInt
            );

        SceneManager.LoadScene(6);
    }

    public IEnumerator PayCoin(string type)
    {
        WWWForm form = new WWWForm();
        form.AddField("method", type);
        form.AddField("uid", Game.player.id);
        WWW www = new WWW(_update, form);
        yield return www;
        var _result = JSON.Parse(www.text);
        Game.player.s_tokens = _result[0]["silver"].AsInt;
        Game.player.g_tokens = _result[0]["gold"].AsInt;
    }

    public IEnumerator CheckName(string s)
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "checkName");
        form.AddField("name", s);
        WWW www = new WWW(_update, form);
        yield return www;
        string _result = www.text;
        FindObjectOfType<Tutorial>().isCheked = true;
        if (_result == "")
        {
            FindObjectOfType<Tutorial>().isValid = true;
        }
        else
        {
            FindObjectOfType<Tutorial>().isValid = false;
        }
    }

    public IEnumerator setRecord(int i)
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "setRecords");
        form.AddField("game", Game.currentGame);
        form.AddField("result", i);
        form.AddField("uid", Game.player.id);
        WWW www = new WWW(_records, form);
        yield return www;
    }

    public void _setRecord(int i)
    {
        StartCoroutine(setRecord(i));
    }

    public void startCheck(string s)
    {
        StartCoroutine(CheckName(s));
    }

    public void endTutorial()
    {
        StartCoroutine(endTuto());
    }

    public void _start()
    {
        StartCoroutine(StartPlay());
    }

    public void _end()
    {
        StartCoroutine(EndPlay());
    }

    public IEnumerator StartPlay()
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "startPlay");
        form.AddField("uid", Game.player.id);
        WWW www = new WWW(_update, form);
        yield return www;
    }

    public IEnumerator EndPlay()
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "endPlay");
        form.AddField("uid", Game.player.id);
        form.AddField("diff", GameInfo.difficulty);
        WWW www = new WWW(_update, form);
        yield return www;
    }

    public void getName()
    {
        Application.ExternalCall("getName");
    }

    public void getID()
    {
        Application.ExternalCall("getID");
    }

    public void getPhoto()
    {
        Application.ExternalCall("getPhoto");
    }

    public void setID(string id)
    {
        uid = int.Parse(id);
        isHaveID = true;
    }

    public void photoURL(string ph)
    {
        photo = ph;
        isHavePhoto = true;
    }

    public void userName(string n)
    {
        _name = n;
        isHaveName = true;
    }

    public void LoadProfile()
    {
        StartCoroutine(GetProfile());
    }

    public void _loadProfile()
    {
        StartCoroutine(_Get_Profile());
    }
}
