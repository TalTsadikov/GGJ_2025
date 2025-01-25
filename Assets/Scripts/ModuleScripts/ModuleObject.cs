using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ModuleObject : MonoBehaviour
{
    [SerializeField] private int _cellSize;
    [SerializeField] private List<Vector2Int> _cellsLocation;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ModuleSO _module;
    private List<GridCell> gridCells = new List<GridCell>();
    private Transform[] children;
    public bool _isPlaced { get; private set;}

    [Header("Drag Variables")]
    private bool dragging = false;
    private float distance;
    private Vector3 startDist;

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        startDist = transform.position - rayPoint;
        ClearOccupied();
        gridCells.Clear();
        _isPlaced = false;
    }

    void OnMouseUp()
    {
        dragging = false;

        if (CheckIfEmpty())
        {
            for (int i = 0; i < gridCells.Count; i++)
            {
                children[i].transform.position = gridCells[i].transform.position;
                gridCells[i].SetOccupied();
            }

            Player.Instance.AddModule(_module);
            _isPlaced = true;
        }
    }

    public virtual void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint + startDist;
        }
    }

    public bool CheckIfEmpty()
    {
        children = gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
        {
            RaycastHit2D hit = Physics2D.Raycast(child.transform.position, Vector2.zero, 0, _layerMask);

            if (hit.collider != null)
            {
                GridCell cell = hit.collider.gameObject.GetComponent<GridCell>();
                if (cell._isOccupied)
                    return false;
                else
                    gridCells.Add(cell);
            }
            else
            {
                Debug.Log("No hit");

                return false;
            }
        }

        return true;
    }

    public void ClearOccupied()
    {
        foreach (GridCell cell in gridCells)
        {
            cell.SetUnoccupied();
        }
    }
}
