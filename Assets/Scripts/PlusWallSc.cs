using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusWallSc : MonoBehaviour
{
    GameObject balls;
    public int numberOfBalls = 1;
    // Start is called before the first frame update
    void Start()
    {
        balls = GameObject.Find("Balls");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ball")
        {
            for(int i = 0; i<=numberOfBalls; i++)
            {
                BallSpawner(other.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

    void BallSpawner(GameObject theBall)
    {
        Vector3 insTarget = new Vector3(theBall.transform.position.x + Random.Range(-0.5f , 0.5f), theBall.transform.position.y + Random.Range(-0.5f , 0.5f),0);
        Instantiate(theBall, insTarget, theBall.transform.rotation, balls.transform);
    }
}
