using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameInfo
{
    public static int difficulty = 0;
    public static string currentVersion = "v.0.9";

    public static string diffName = "Тест";

    public static int saveResult = 0;
    public static int saveLives = 4;

    public static int extraRound = 0;


    public static bool isPlay = false;
    public static int oldExp;
    public static int oldLvl;

    public static List<string> recordNames = new List<string>();
    public static List<string> recordValues = new List<string>();
}
