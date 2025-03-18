using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public int damage = 4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ignore objects with tag attackpoint

        if (collision.CompareTag("AttackPoint"))
            return;

        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>()?.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
