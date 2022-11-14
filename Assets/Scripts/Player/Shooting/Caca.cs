using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caca : MonoBehaviour
{
    [SerializeField] private float speed;
    public int dmg;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Obstacle"))
        {
            collision.GetComponent<MeleeEnemy>().TakeDmg(dmg);
            Destroy(gameObject);
        }
    }


}
