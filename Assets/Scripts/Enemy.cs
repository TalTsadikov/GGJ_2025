using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    [SerializeField] private int _currentHP;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rigidbody2D _rb;
    private bool _isAlive => _currentHP > 0;
    private GameObject _tower;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _tower = GameObject.FindGameObjectWithTag("Tower");
        _currentHP = _maxHP;
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
        Vector2 directionToTarget = (_tower.transform.position - transform.position);

        _rb.velocity = directionToTarget * _speed;

        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
    }
}
