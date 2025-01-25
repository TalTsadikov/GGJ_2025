using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public Vector2Int _gridPosition { get; private set; }
    public bool _isOccupied { get; private set; }

    public void SetGridPos(Vector2Int pos)
    {
        _gridPosition = pos;
    }

    public void SetOccupied()
    {
        _isOccupied = true;
    }

    public void SetUnoccupied()
    {
        _isOccupied = false;
    }
}
