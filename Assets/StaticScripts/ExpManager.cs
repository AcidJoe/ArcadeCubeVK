using UnityEngine;
using System.Collections;

public static class ExpManager
{
    public static int expToPrev = 0;
    public static int expToNext = 50;

    public static int Calculate(int exp)
    {
        return exp - expToPrev;
    }

    public static void lvlUp()
    {
        expToPrev = expToNext;
        expToNext *= 2;
    }
}
