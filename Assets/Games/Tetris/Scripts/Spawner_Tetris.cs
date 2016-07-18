using UnityEngine;
using System.Collections;

public class Spawner_Tetris : MonoBehaviour
{
    public GameObject[] shapes;

    public int next;

    void Start ()
    {
        spawnFirst();
    }

    public void spawnNext()
    {
        Instantiate(shapes[next],
                    transform.position,
                    Quaternion.identity);

        next = Random.Range(0, shapes.Length);
    }

    public void spawnFirst()
    {
        int i = Random.Range(0, shapes.Length);

        Instantiate(shapes[i],
                    transform.position,
                    Quaternion.identity);

        next = Random.Range(0, shapes.Length);
    }
}
