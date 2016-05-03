using UnityEngine;
using System.Collections;

public class Spawner_Tetris : MonoBehaviour
{
    public GameObject[] shapes;

    void Start ()
    {
        spawnNext();
    }

    public void spawnNext()
    {
        // Random Index
        int i = Random.Range(0, shapes.Length);

        // Spawn Group at current Position
        Instantiate(shapes[i],
                    transform.position,
                    Quaternion.identity);
    }
}
