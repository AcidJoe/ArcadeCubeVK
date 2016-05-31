using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakePoolManager : MonoBehaviour
{
    public GameObject prefab;
    Vector2 spawnPoint;

    Queue<GameObject> bits;

    int bitsCount;
    public bool isReady;

	void Start ()
    {
        isReady = false;
        spawnPoint = new Vector3(1000, 1000,0);
        bitsCount = 100;

        bits = new Queue<GameObject>();

        for(int i = 0; i <= bitsCount; i++)
        {
            var newBit = Instantiate(prefab, spawnPoint, Quaternion.identity);
            GameObject bit = newBit as GameObject;

            bits.Enqueue(bit);
        }

        isReady = true;
    }
	
	void Update ()
    {
	
	}

    public GameObject Create(Vector3 pos)
    {
        if(bits.Count != 0)
        {
            GameObject newBit = bits.Dequeue();
            newBit.transform.position = pos;
            return newBit;
        }
        else
        {

        }

        return null;
    }

    public void Push(GameObject g)
    {
        g.transform.position = spawnPoint;
        bits.Enqueue(g);
    }
}
