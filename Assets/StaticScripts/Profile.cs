using UnityEngine;
using System.Collections;

public class Profile
{
    public string id;
    public string _name;
    public string photo;

    public int b_tokens;
    public int s_tokens;
    public int g_tokens;

    public int lvl;
    public int exp;

    public Profile(string n)
    {
        _name = n;

        b_tokens = 50;
        s_tokens = 50;
        g_tokens = 50;

        lvl = 1;
        exp = 0;
    }

    public Profile(string n, string ph, string _id, int silv, int gold, int lv, int ex)
    {
        _name = n;
        photo = ph;
        id = _id;

        s_tokens = silv;
        g_tokens = gold;

        lvl = lv;
        exp = ex;
    }

    public void PayB_coin()
    {

    }

    public void PayS_coin()
    {
        s_tokens--;
    }

    public void PayG_coin()
    {
        g_tokens--;
    }
}
