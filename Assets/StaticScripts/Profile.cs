using UnityEngine;
using System.Collections;

public class Profile
{
    public string name;

    public int b_tokens;
    public int s_tokens;
    public int g_tokens;

    public int lvl;
    public int exp;

    public Profile(string n)
    {
        name = n;

        b_tokens = 50;
        s_tokens = 50;
        g_tokens = 50;

        lvl = 1;
        exp = 0;
    }

    public void PayB_coin()
    {
        b_tokens--;
    }
}
