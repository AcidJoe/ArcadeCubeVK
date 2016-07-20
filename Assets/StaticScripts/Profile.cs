using UnityEngine;
using System.Collections;

public class Profile
{
    public int id;
    public string _name;
    public string photo;

    public int b_tokens;
    public int s_tokens;
    public int g_tokens;

    public int lvl;
    public int exp;
    public int exp_to_next;

    public int isEndTutorial;

    public Profile(string n)
    {
        _name = n;

        b_tokens = 50;
        s_tokens = 50;
        g_tokens = 50;

        lvl = 1;
        exp = 0;
    }

    public Profile(string n, string ph, int _id, int silv, int gold, int lv, int ex, int exp_n, int tut)
    {
        _name = n;
        photo = ph;
        id = _id;

        s_tokens = silv;
        g_tokens = gold;

        lvl = lv;
        exp = ex;
        exp_to_next = exp_n;

        isEndTutorial = tut;
    }

    public void PayB_coin()
    {

    }

    public void PayS_coin()
    {
    }

    public void PayG_coin()
    {
    }
}
