using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class SocialManager: MonoBehaviour
{
    public Profile profile;
    public TestIntro ti;

    public string uid;
    public string photo;
    public string _name = "Default";

    static string _profile = "https://www.acidjoe.ru/Games/ACTest/PHP/profile.php";

    public bool isHaveName = false;
    public bool isHaveID = false;
    public bool isHavePhoto = false;

    public IEnumerator GetProfile()
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "profile");
        form.AddField("uid", int.Parse(uid));
        form.AddField("name", _name);
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
            _result[0]["exp"].AsInt);

        SceneManager.LoadScene(6);
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
        uid = id;
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
}
