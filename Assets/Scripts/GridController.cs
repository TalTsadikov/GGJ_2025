using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] List<GridCell> _grid;

    private void Start()
    {
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
    }
}
