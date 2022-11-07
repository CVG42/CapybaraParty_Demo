using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HPManager : MonoBehaviour
{
    public float StartingHP;
    public float currentHP { get; private set; }
    public event EventHandler playerDeath;

    private void Awake()
    {
        currentHP = StartingHP;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            currentHP -= MeleeEnemy._damage;
        }
        if(currentHP <= 0)
        {
            playerDeath?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}
