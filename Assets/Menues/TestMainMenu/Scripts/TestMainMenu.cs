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

    void Start()
    {
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
    }
}
