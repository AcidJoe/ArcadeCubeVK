using UnityEngine;
using System.Collections;

public class ArkanoidBrick : MonoBehaviour
{
    ArcanoidManager gameManager;

    public int hitsToKill;
    public int points;
    public int pointsForHit;
    private int numberOfHits;

    public GameObject oneHitDetector;

    void Start()
    {
        gameManager = FindObjectOfType<ArcanoidManager>();
        points = gameManager.points;
        pointsForHit = gameManager.points - 1;
        oneHitDetector.SetActive(false);
        numberOfHits = 0;
    }

    void Update()
    {
        if (hitsToKill - numberOfHits == 1)
        {
            oneHitDetector.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            gameManager.score += pointsForHit;
            numberOfHits++;

            if (numberOfHits == hitsToKill)
            {
                // уничтожаем объект
                StartCoroutine(_Destroy());
            }
        }
    }

    IEnumerator _Destroy()
    {
        gameManager.score += points;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
