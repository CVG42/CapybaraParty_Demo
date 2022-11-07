using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlocks : MonoBehaviour
{
    public GameObject visibleBlocks;
    public GameObject invisibleBlocks;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.contacts[0].normal.y > 0)
        {
            visibleBlocks.SetActive(true);
            Destroy(invisibleBlocks);
        }              
    }

}
