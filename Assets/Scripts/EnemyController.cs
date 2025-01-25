using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    [SerializeField] float _radius = 5f;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, 1f);
    }

    private void SpawnEnemy()
    {
        Vector3 pos = Random.insideUnitCircle.normalized * _radius;
        Instantiate(_enemy, transform.position + pos, Quaternion.identity);
    }
}
