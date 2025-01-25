using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] List<GridCell> _grid;
    [SerializeField] GameObject _emptyCell;
    [SerializeField] Transform _parentTransform; 

    private void Start()
    {
        _parentTransform = transform;
        CreateGrid();
    }

    private void CreateGrid()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GridCell cell = new GridCell();
                Vector2Int pos = new Vector2Int(i, j);
                cell.SetGridPos(pos);
                _grid.Add(cell);
            }
        }

        foreach (GridCell cell in _grid)
        {
            Vector3 worldPosition = new Vector3(cell._gridPosition.x, cell._gridPosition.y, 0) + _parentTransform.position;

            GameObject instantiatedCell = Instantiate(_emptyCell, worldPosition, Quaternion.identity, _parentTransform);
        }
    }
}
