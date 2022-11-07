using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public int HP;
    public static int _damage = 1;

    public void TakeDmg(int dmg)
    {
        HP -= dmg;
        if(HP <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        foreach(ContactPoint2D point in other.contacts)
        {
            if(point.normal.y <= -0.9)
            {
                other.gameObject.GetComponent<PlayerController>().Rebound();
                Destroy(gameObject);
            }
        }
    }
}
