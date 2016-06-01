using UnityEngine;
using System.Collections;

public class SnakeFood : MonoBehaviour
{
    public SnakeManager manager;
    public Snake snake;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<SnakeManager>();
        snake = GameObject.FindGameObjectWithTag("Player").GetComponent<Snake>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<Snake>().lenght += 1;
            manager.score += DifficultyManager.snakepoints;
        }

        manager.food.Clear();
        Destroy(gameObject);
    }
}
