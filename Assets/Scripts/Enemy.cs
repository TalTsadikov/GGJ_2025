using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    [SerializeField] private int _currentHP;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rigidbody2D _rb;  // Rigidbody2D for physics-based movement
    private bool _isAlive => _currentHP > 0;
    private GameObject _tower;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _tower = GameObject.FindGameObjectWithTag("Tower");
        _currentHP = _maxHP;

        // Disable gravity if you don't want the enemy to fall
        _rb.gravityScale = 0f;
    }

    private void Update()
    {
        if (_isAlive)
        {
            MoveTowardTarget();
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHP -= damage;

        if (!_isAlive)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void MoveTowardTarget()
    {
        // Calculate the direction towards the target
        Vector2 targetPosition = _tower.transform.position;
        Vector2 directionToTarget = (targetPosition - (Vector2)transform.position).normalized;

        // Use Rigidbody2D to move towards the target
        _rb.MovePosition((Vector2)transform.position + directionToTarget * _speed * Time.deltaTime);

        // Optionally rotate the enemy to face the target
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
    }
}
