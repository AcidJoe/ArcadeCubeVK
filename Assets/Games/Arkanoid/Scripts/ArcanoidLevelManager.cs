using UnityEngine;
using System.Collections;

public class ArcanoidLevelManager : MonoBehaviour
{
    ArcanoidGrid grid;
    ArcanoidLevelMap map;

    int[,] levelMap;

    public GameObject brick;
    public GameObject weekBrick;

    public bool isLevelCreated;

	void Start ()
    {
        grid = GetComponent<ArcanoidGrid>();
        map = GetComponent<ArcanoidLevelMap>();

        isLevelCreated = false;
	}
	
	void Update ()
    {
        if (!isLevelCreated)
        {
            CreateLevel();
        }
	}

    void CreateLevel()
    {
        int ran = Random.Range(1, 1);

        levelMap = map.map(ran);

        for (int i = 0; i <= 7; i++)
        {
            for (int j = 0; j <= 14; j++)
            {
                if (levelMap[i, j] == 1)
                {
                    foreach (ArkCell ac in grid.cells)
                    {
                        if (ac.row == i && ac.rowPos == j)
                        {
                            Instantiate(weekBrick, ac.pos, Quaternion.identity);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                else if (levelMap[i, j] == 2)
                {
                    foreach (ArkCell ac in grid.cells)
                    {
                        if (ac.row == i && ac.rowPos == j)
                        {
                            Instantiate(brick, ac.pos, Quaternion.identity);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }

        isLevelCreated = true;
    }
}
