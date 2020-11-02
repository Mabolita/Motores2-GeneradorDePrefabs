using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GridVisualizer gridVisualizer;

    [Range(3,20)]
    public int width, length;

    private MapGrid _grid;
    private void Start()
    {
        _grid = new MapGrid(width,length);
        gridVisualizer.VisualizeGrid(width,length);
    }

    
}
