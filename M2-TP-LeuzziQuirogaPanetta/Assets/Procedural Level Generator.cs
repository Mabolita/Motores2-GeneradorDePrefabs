﻿using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;


public class ProceduralLevelGenerator : EditorWindow
{
    public GameObject prefab1, prefab2, prefab3, prefab4, prefab5;

    Vector2 scrollPos;
    public List<GameObject> prefabList=new List<GameObject>();
    //public List<int> deleteList = new List<int>();
    public List<int> amountList=new List<int>();
    //public List<T> list = new List<T>();

    public int deleteList;

    [MenuItem("Tools/Procedural Level Generator")]
    public static void OpenWindow()
    {
        //GetWindow<PrefabCreator>("Prefab Creator");
        ProceduralLevelGenerator window = (ProceduralLevelGenerator)GetWindow(typeof(ProceduralLevelGenerator));
        //window.minSize = new Vector2(600, 450);
        //window.maxSize = new Vector2(600, 450);
        window.Show();

    }

    private void OnGUI()
    {
        //Elección de título, me gusta más centrado pero no se puede poner en negrita (?)
        var style = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter };
        EditorGUILayout.LabelField("Choose 1 to 4 prefabs to create the level", style, GUILayout.ExpandWidth(true));

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Choose 1 to 4 prefabs to create the level", EditorStyles.boldLabel);
        //EditorGUILayout.HelpBox("This tool allows you to create levels...", MessageType.Info);
        //EditorGUILayout.("This tool allows you to create levels...", MessageType.Info);


        //Esto está comentado para que elijamos entre los 2 layout: 4 prefabs en horizoantal
        //o 2 filas de 2. Queda mejor el de 4 pero no es fácil de escalar.

        /* 2 y 2
        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        prefab1 = (GameObject)EditorGUILayout.ObjectField("", prefab1, typeof(GameObject), false);
        prefab2 = (GameObject)EditorGUILayout.ObjectField("", prefab2, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        scale1 = EditorGUILayout.IntField("", scale1);
        scale2 = EditorGUILayout.IntField("", scale2);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        prefab3 = (GameObject)EditorGUILayout.ObjectField("", prefab3, typeof(GameObject), false);
        prefab4 = (GameObject)EditorGUILayout.ObjectField("", prefab4, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        scale3 = EditorGUILayout.IntField("Scale", scale3);
        scale4 = EditorGUILayout.IntField("Scale", scale4);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();*/

        //4 juntos
        //Espacio para agregar los prefabs.
        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.EndHorizontal();

        //PONER EL BOTÓN ADD ARRIBA DE TODO
        if (GUILayout.Button("Add another prefab") && prefabList.Count <= 24)
        {
            prefabList.Add(null);
            amountList.Add(0);
            deleteList = EditorGUILayout.IntField("algo list", deleteList);

        }


        //PONER SCROLLBAR VERTICAL
        for (int i = 0; i < prefabList.Count; i++)
        {
            EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(1000), GUILayout.Height(1000));
            //EditorGUILayout.BeginV

            
            EditorGUILayout.BeginHorizontal();
            prefabList[i] = (GameObject)EditorGUILayout.ObjectField("Prefab "+(i+1), prefabList[i], typeof(GameObject), false);
            

            amountList[i] = EditorGUILayout.IntField("",amountList[i]);
            if (GUILayout.Button("Delete prefab"))
            {
                prefabList.RemoveAt(i);
                amountList.RemoveAt(i);
                Repaint();

            }
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndHorizontal();
        }

        

        if (prefabList.Count >= 11) 
        {
            EditorGUILayout.HelpBox("Using more than 10 prefabs could slow the process.",MessageType.Warning);
            if (prefabList.Count >= 24)
            {
                EditorGUILayout.HelpBox("This tool does not work with more than 25 prefabs.", MessageType.Warning);
            }
        }

        //if (GUILayout.Button("Remove prefab"))
        //{
            
        //}



        EditorGUILayout.Space();

        EditorGUI.BeginDisabledGroup(prefab1 == null || prefab2 == null || prefab3 == null || prefab4 == null);
        //Posición del spawn, sólo para probar, esto se va a borrar después.
        Vector3 spawnPos1 = new Vector3(-1, 0, 0);
        Vector3 spawnPos2 = new Vector3(0, 0, 1);
        Vector3 spawnPos3 = new Vector3(1, 0, 0);
        Vector3 spawnPos4 = new Vector3(0, 0, -1);

        if (GUILayout.Button("Create Level"))
        {
            
            //Que se instancien como hijos de un objeto vacio también estaría bueno que
            //pudieramos nombrar los grupos que instanciamos, porque si no nos gusta
            //algo cuando se crea el mapa, se puede borrar y listo.
            //Listo-> proyecto recu
            Instantiate(prefab1, spawnPos1, Quaternion.identity);
            Instantiate(prefab2, spawnPos2, Quaternion.identity);
            Instantiate(prefab3, spawnPos3, Quaternion.identity);
            Instantiate(prefab4, spawnPos4, Quaternion.identity);
        }

        EditorGUI.EndDisabledGroup();

    }
}