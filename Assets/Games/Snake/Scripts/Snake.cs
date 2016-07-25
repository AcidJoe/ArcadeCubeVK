using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    public GameObject snakeBit;
    public float spawnTime;
    public int lenght;

    public SnakeUI ui;

    public bool isStart;

    SnakePoolManager spm;

    Queue<GameObject> bits;

    Vector3 moveFwd;
    Vector3 prevPos;
    Vector3 nextPos;

    public enum State { up, down, left, right }

    State currentState;

    bool isChosen;

    void Start ()
    {
        ui = FindObjectOfType<SnakeUI>();
        isStart = false;
        spm = FindObjectOfType<SnakePoolManager>();
        spawnTime = DifficultyManager.snakespeed;
        lenght = 3;
        bits = new Queue<GameObject>();
        setState(State.right);
    }
	
	void Update ()
    {
        if (!isChosen)
        {
            if (currentState == State.up || currentState == State.down)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    setState(State.right);
                    isChosen = true;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    setState(State.left);
                    isChosen = true;
                }
            }

            if (currentState == State.left || currentState == State.right)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    setState(State.up);
                    isChosen = true;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    setState(State.down);
                    isChosen = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnTime /= 3;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            spawnTime *= 3;
        }
    }

    public void startMove()
    {
        isStart = true;
        Invoke("MoveSnake", spawnTime);
    }

    void MoveSnake()
    {
        isChosen = false;
        prevPos = transform.position;
        nextPos = transform.position += moveFwd;
        if (nextPos.x > 15.0f || nextPos.x < -15.0f 
            || nextPos.y > 10.0f || nextPos.y < -10.0f)
        {
            GameOver();
        }

        transform.position = nextPos;
        createBit();

        Invoke("MoveSnake", spawnTime);
    }


    void createBit()
    {
        GameObject bit = spm.Create(prevPos);

        bits.Enqueue(bit);

        if (bits.Count > lenght && bits.Count != 0)
        {
            spm.Push(bits.Dequeue());
        }
    }

    void setState(State state)
    {
        switch (state)
        {
            case State.up:
                moveFwd = Vector2.up;
                break;
            case State.down:
                moveFwd = -Vector2.up;
                break;
            case State.left:
                moveFwd = -Vector2.right;
                break;
            case State.right:
                moveFwd = Vector2.right;
                break;
        }
        currentState = state;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Tail")
        {
            GameOver();
        }
    }

    void GameOver()
    {
        spawnTime *= 0;
        ui.GameOver();
    }
}
