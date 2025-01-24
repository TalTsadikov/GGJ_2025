using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ModuleObject : MonoBehaviour
{
    [SerializeField] private int _cellSize;
    [SerializeField] private List<Vector2Int> _cellsLocation;

    [Header("Drag Variables")]
    private bool dragging = false;
    private float distance;
    private Vector3 startDist;
    
    private void OnMouseEnter()
    {
        Debug.Log("Mouse is over " + gameObject.name);
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        startDist = transform.position - rayPoint;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint + startDist;

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
            }
    }
}