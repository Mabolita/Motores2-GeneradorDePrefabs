using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MapGrid
{
  // Define el tamaño del grid
  private int _width, _lenght;
  private Cell[,] _cellGrid;

  public int Width 
  { get => _width; }

  public int Lenght 
  { get => _lenght; }

  public MapGrid(int width, int lenght)
  {
    this._width= width;
    this._lenght = lenght;
    CreateGrid();
  }

  private void CreateGrid()
  {
    //creamos la Cell con los valores que decidamos previamente en largo y ancho
    _cellGrid = new Cell[_lenght,_width];
    {
      for (int row = 0; row < _lenght; row++)
      {
        for (int col = 0; col < _width; col++)
        {
          //definimos col (columna) como un valor X y row (fila) como un valor z
          _cellGrid[row, col] = new Cell(col,row);
        }

      }
    }
  }

  //si el espacio ya esta tomado isTaken se activa para no superponer objetos. el ultimo bool peromite que el espacio este vacio
  public void SetCell(int x, int z, CellObjectType objectType, bool isTaken = false)
  {
    _cellGrid[z, x].ObjectType = objectType;
    _cellGrid[z, x].IsTaken = isTaken;
  }
  
  public void SetCell(float x, float z, CellObjectType objectType, bool isTaken = false)
  {
    SetCell((int) x, (int) z, objectType, isTaken);
  }

  public bool IsCellTaken(int x, int z)
  {
    return _cellGrid[z, x].IsTaken;
  }
  
  public bool IsCellTaken(float x, float z)
  {
    return _cellGrid[(int)z, (int)x].IsTaken;
  }

  // si los valores son mayores al largo y/o ancho devuelve un false, de lo contrario sigue igual
  public bool IsCellValid(float x, float z)
  {
    if (x >= _width || x < 0 || z >= _lenght || z < 0)
    {
      return false;
    }

    return true;
  }

  // nos da el espacio que estamos pidiendo
  public Cell GetCell(int x, int z)
  {
    if (IsCellValid(x, z) == false)
    {
      return null;
    }

    return _cellGrid[z, x];
  }
  
  public Cell GetCell(float x, float z)
  {
    return GetCell((int) x, (int) z);
  }
  
  public int CalculateIndexForCoordinates(int x, int z)
  {
    return x + z * _width;
  }
  
  public int CalculateIndexForCoordinates(float  x, float z)
  {
    return (int)x + (int)z * _width;
  }

  public void CheckCoordinates()
  {
    for (int i = 0; i < _cellGrid.GetLength(0); i++)
    {
      StringBuilder b = new StringBuilder();
      for (int j = 0; j < _cellGrid.GetLength(1); j++)
      {
        b.Append(j + "," + i + "");
      }
      Debug.Log(b.ToString());
    }
  }
}
