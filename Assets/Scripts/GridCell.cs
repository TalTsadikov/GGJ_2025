using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public Vector2Int _gridPosition { get; private set; }
    public bool _isOccupied { get; private set;}
    private ModuleSO _module;

    public void SetGridPos(Vector2Int pos)
    {
        _gridPosition = pos;
    }

    public void SetModule(ModuleSO module)
    {
        _module = module;
    }
}
