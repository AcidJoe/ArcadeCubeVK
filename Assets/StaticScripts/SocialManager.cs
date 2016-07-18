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

    public IEnumerator GetProfile()
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "profile");
        form.AddField("uid", uid);
        form.AddField("diff", GameInfo.difficulty);
        WWW www = new WWW(_profile, form);
        yield return www;
        var _result = JSON.Parse(www.text);
        Game.player = new Profile(
            _name, 
            photo,
            uid,
            _result[0]["silver"].AsInt,
            _result[0]["gold"].AsInt,
            _result[0]["lvl"].AsInt,
            _result[0]["exp"].AsInt,
            _result[0]["exp_next"].AsInt);

        SceneManager.LoadScene(6);
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
            Game.player._name,
            photo,
            Game.player.id,
            _result[0]["silver"].AsInt,
            _result[0]["gold"].AsInt,
            _result[0]["lvl"].AsInt,
            _result[0]["exp"].AsInt,
            _result[0]["exp_next"].AsInt);

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
