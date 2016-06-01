using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidsManager : MonoBehaviour
{
    public int score;

    public Vector3 spawn_point_1;
    public Vector3 spawn_point_2;
    public Vector3 spawn_point_3;
    public Vector3 spawn_point_4;

    public bool isStart;

    public int astroCount;

    void Start()
    {
        isStart = false;

        spawn_point_1 = new Vector3(-18, Random.Range(-1, 1));
        spawn_point_2 = new Vector3(18, Random.Range(-1, 1));
        spawn_point_3 = new Vector3(Random.Range(-1,1), 11);
        spawn_point_4 = new Vector3(Random.Range(-1, 1), -11);
    }
	
	void Update ()
    {
	
	}
}
