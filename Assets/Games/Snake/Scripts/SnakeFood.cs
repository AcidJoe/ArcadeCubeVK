using UnityEngine;
using System.Collections;

public class SnakeFood : MonoBehaviour
{
    public SnakeManager manager;
    public Snake snake;

    SnakeSound sound;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<SnakeManager>();
        snake = GameObject.FindGameObjectWithTag("Player").GetComponent<Snake>();
        sound = FindObjectOfType<SnakeSound>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        sound.Take();

        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<Snake>().lenght += 1;
            manager.score += DifficultyManager.snakepoints;
            manager.collectedFood++;
        }
        manager.food.Clear();
        Destroy(gameObject);
    }
}
