using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

//credits:
// https://www.youtube.com/watch?v=9i0UGVUKiaE

public class Health : MonoBehaviour
{

    public int currentHealth;
    public int currentMaxHealth;
    private Stopwatch invunrabilityCooldown;
    public long cooldownMilliseconds;

    void Start()
    {
        invunrabilityCooldown = new Stopwatch();
        invunrabilityCooldown.Start();
    }

    public void DmgUnit(int dmgAmount)
    {
        if (currentHealth > 0 && invunrabilityCooldown.ElapsedMilliseconds > cooldownMilliseconds)
        {
            currentHealth -= dmgAmount;
            invunrabilityCooldown.Restart();
        }
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}