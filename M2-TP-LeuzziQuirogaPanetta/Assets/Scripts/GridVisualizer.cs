using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridVisualizer : MonoBehaviour
{
   public GameObject groundPrefab;

   // direccion del quad (ground) para que mire hacia arriba y lo escala
   public void VisualizeGrid(int width, int lenght)
   {
      Vector3 position = new Vector3(width/2f,0,lenght/2f);
      Quaternion rotation = Quaternion.Euler(90,0,0);
      var board= Instantiate(groundPrefab, position, rotation);
      board.transform.localScale = new Vector3(width,lenght,1);
   }
}
