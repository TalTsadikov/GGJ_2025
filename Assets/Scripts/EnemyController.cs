using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject GameObject;
    [SerializeField] float _radius = 15f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Random.insideUnitCircle.normalized * _radius;
        Instantiate(GameObject, pos, Quaternion.identity);
    }

    
}
