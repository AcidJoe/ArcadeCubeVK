using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeManager : MonoBehaviour
{
    public List<SnakeFood> food;

    public GameObject snakeFood;

    void Start ()
    {
        food = new List<SnakeFood>();
    }
	
	void Update ()
    {
        if (food.Count < 1)
        {
            SpawnFood(foodSpawnPoint());
        }
    }

    void SpawnFood(Vector2 v)
    {
        var newFood = Instantiate(snakeFood, v, Quaternion.identity);
        food.Add(newFood as SnakeFood);
    }

    Vector2 ran()
    {
        int x = Random.Range(-15, 15);
        int y = Random.Range(-10, 10);

        return new Vector2(x, y);
    }

    bool Check(Vector2 vec)
    {
        if (Physics2D.OverlapCircle(vec, 0.2f))
        {
            return true;
        }

        return false;
    }

    Vector2 foodSpawnPoint()
    {
        Vector2 vec = ran();
        while (Check(vec))
        {
            vec = ran();
        }

        return vec;
    }
}
