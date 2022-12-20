using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Unity.VisualScripting;

public class Controls : MonoBehaviour
{
    Animator animator;
    private Rigidbody2D rb;  //rb as in rigidbody
    float inputX;
    float inputY;

    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;

    //for attack function
    public LayerMask enemyLayer;    //makes sure the player attacks the enemy (right layer)
    public int attackDamage = 40;
    public float attackRange = 0.5f;
    public Transform attackPoint;   //ig to move the attack point when the player moves?

    //cooldown on attack;
    public Stopwatch timing;
    public long cooldown;

    public SoundManager soundManager; // ref to the SoundManager


    // Start is called before the first frame update
    void Start()
    {
        //grabbing components
        moveSpeed = 0.3f;
        jumpForce = 9f;
        isJumping = false;
        animator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        timing = new Stopwatch();
        timing.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //grabs horizontal movement input
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        // sets bind for attack and applies a 0.5 sec cooldown
        if (Input.GetKeyDown("f"))
        {
            timing.Stop();
            cooldown = timing.ElapsedMilliseconds;
            if (cooldown >= 500)
            {
                Attack();
                timing.Reset();
            }
            timing.Start();
        }

        
    }

    //putting physics + animation triggers in fixed update
    //FixedUpdate is called every frame
    private void FixedUpdate()
    {
        //flips sprite on x-axis when changing direction
        if (inputX > 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        if (inputX < 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        //give character velocity to move
        if(inputX > 0 || inputX < 0)
        {
            if (rb.velocity.x < 10f && rb.velocity.x > -10f)
            {
                rb.AddForce(new Vector2(inputX * moveSpeed, 0f), ForceMode2D.Impulse);
            }
        }
        if(!isJumping && inputY > 0)
        {
          rb.AddForce(new Vector2(0f, inputY * jumpForce), ForceMode2D.Impulse);
          // calls jump sound effect on action
          soundManager.PlayJumpSfx();
        }


        //set animation triggers for run (positive) and idle (negative)
        if (Mathf.Abs(inputX) > 0)
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }

    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        //[] means array
        //creates array with every layer an enemy could be on and if they collide with our attack point
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in enemies) //for each possible enemy collision
        {
            print("we hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage); //make the enemy take damage using TakeDamage() function
        }
 
    }
    // jump check / isgrounded function
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}