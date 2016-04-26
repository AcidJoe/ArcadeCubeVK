using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    public GameObject snakeBit;
    public float spawnTime;
    public int lenght;

    Queue<GameObject> bits;

    Vector3 moveFwd;
    Vector3 prevPos;
    Vector3 nextPos;
    Quaternion prevRot;

    public enum State { up, down, left, right }

    State currentState;

    bool isChosen;

    void Start ()
    {
        spawnTime = 0.4f;
        lenght = 3;
        bits = new Queue<GameObject>();
        setState(State.right);
        Invoke("MoveSnake", spawnTime);
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

    void MoveSnake()
    {
        isChosen = false;
        prevPos = transform.position;
        prevRot = transform.rotation;
        nextPos = transform.position += moveFwd;
        if (nextPos.x > 15.0f)
        {
            nextPos.x = -15.0f;
        }
        if (nextPos.x < -15.0f)
        {
            nextPos.x = 15.0f;
        }
        if (nextPos.y > 10.0f)
        {
            nextPos.y = -10.0f;
        }
        if (nextPos.y < -10.0f)
        {
            nextPos.y = 10.0f;
        }

        transform.position = nextPos;

        createBit();
        Invoke("MoveSnake", spawnTime);
    }


    void createBit()
    {
        var newBit = Instantiate(snakeBit, prevPos, prevRot);
        GameObject bit = newBit as GameObject;
        bits.Enqueue(bit);

        if (bits.Count > lenght)
        {
            Destroy(bits.Dequeue());
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
}
