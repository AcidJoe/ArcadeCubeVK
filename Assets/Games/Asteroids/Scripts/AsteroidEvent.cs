using UnityEngine;
using System.Collections;

public class AsteroidEvent : MonoBehaviour
{
    public delegate void Crash();

    public static Crash crashed;

    public static void OnCrash()
    {
        crashed();
    }
}
