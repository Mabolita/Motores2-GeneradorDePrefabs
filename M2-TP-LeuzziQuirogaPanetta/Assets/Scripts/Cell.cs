using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    private int _x, _z;
    private bool _isTaken;
    private CellObjectType _objectType;

    public int X 
    { get => _x; }
    
    public int Z 
    { get => _z; }

    public bool IsTaken
    { get => _isTaken; set => _isTaken = value; }

    public CellObjectType ObjectType 
    { get => _objectType; set => _objectType = value; }

    public Cell(int x, int z)
    {
        this._x = x;
        this._z = z;
        this._objectType = CellObjectType.Empty;
        _isTaken = false;
    }
    
}

public enum CellObjectType
{
    Empty,
    Road,
    Obstacle,
    Start,
    Exit,
    
}


