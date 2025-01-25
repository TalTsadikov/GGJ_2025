using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log($"Dealt {damage} damage to {collision.name}.");
            Destroy(gameObject);
        }
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
