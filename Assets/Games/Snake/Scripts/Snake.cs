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

    bool isChoosen = false;

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
	
	}

    void MoveSnake()
    {
        isChoosen = false;
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
