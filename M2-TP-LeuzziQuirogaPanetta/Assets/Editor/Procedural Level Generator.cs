using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;


public class ProceduralLevelGenerator : EditorWindow
{
    public GameObject prefab1, prefab2, prefab3, prefab4, prefab5;

    public List<GameObject> prefabList=new List<GameObject>();
    

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
        prefab1 = (GameObject)EditorGUILayout.ObjectField("", prefab1, typeof(GameObject), false);
        prefab2 = (GameObject)EditorGUILayout.ObjectField("", prefab2, typeof(GameObject), false);
        prefab3 = (GameObject)EditorGUILayout.ObjectField("", prefab3, typeof(GameObject), false);
        prefab4 = (GameObject)EditorGUILayout.ObjectField("", prefab4, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();



        if (GUILayout.Button("Add prefab vv"))
        {
            //if (prefabList.Count <= 25)
            //{
                //prefabList.Add(prefab2); AÑADIR UN ONJECTFIELD EN FALSE
                prefab5 = (GameObject)EditorGUILayout.ObjectField("", prefab5, typeof(GameObject), false);

                if (prefabList.Count <= 10)
                {
                    EditorGUILayout.HelpBox("Using more than 10 prefabs " +
                        "could make the process take longer",MessageType.Info);
                }
            //}
        }



        /*
        if (GUILayout.Button("Remove prefab"))
        {
            if (prefabList.Count>=1)
            {
                prefabList.RemoveAt(prefabList.Count + 1);
            }
        }*/



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
            //algo cuando se crea el mapa, se puede borrar y fue.
            Instantiate(prefab1, spawnPos1, Quaternion.identity);
            Instantiate(prefab2, spawnPos2, Quaternion.identity);
            Instantiate(prefab3, spawnPos3, Quaternion.identity);
            Instantiate(prefab4, spawnPos4, Quaternion.identity);
        }

        EditorGUI.EndDisabledGroup();

    }
}