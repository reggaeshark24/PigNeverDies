using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Yeet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyTimer = new Stopwatch();
        enemyTimer.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Push();
    }

    public float distance;
    public Transform enemy;
    public Stopwatch enemyTimer; 
    public Rigidbody2D rb;

    //credits: https://adamwreed93.medium.com/how-to-make-pushable-objects-in-unity-ecd0fba5e9ea
    //apply force to player to push them when attacked
    void Push()
    {
        distance = Vector2.Distance(-1*enemy.position, transform.position); //function of vector2, finds distance between 2 points

        if ((distance < 2) && (enemyTimer.ElapsedMilliseconds >= 1000))
        {
            if (enemy.position.x > transform.position.x)    // enemy is to the right
            {
                rb.velocity = new Vector2(-50, 0);
            }
            else
            {
                rb.velocity = new Vector2(50, 0);
            }
            enemyTimer.Restart();
        }
    }
}
