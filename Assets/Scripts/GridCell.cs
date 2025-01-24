using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public Vector2Int _gridPosition { get; private set; }
    private bool _isOccupied = false;
    private ModuleSO _module;

    public void SetGridPos(Vector2Int pos)
    {
        _gridPosition = pos;
    }
}
