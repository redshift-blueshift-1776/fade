using UnityEngine;
// using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;
// using TMPro;
using UnityEngine.SceneManagement;

public class City_Generator : MonoBehaviour
{
    [SerializeField] public int x_dimension; // Should be an odd number
    [SerializeField] public int z_dimension; // Should be an odd number
    [SerializeField] public float x_length;
    [SerializeField] public float z_length;
    [SerializeField] public float sidewalk_width;
    [SerializeField] public float road_width;

    [Header("Prefabs")]
    [SerializeField] public GameObject sidewalk;
    [SerializeField] public GameObject building;
    [SerializeField] public GameObject lightpole;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateCity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateCity() {
        for (int i = 0; i < x_dimension; i++) {
            for (int j = 0; j < z_dimension; j++) {
                GameObject newBuilding = Instantiate(building);
                float globalX = (i - (x_dimension - 1) / 2) * x_length;
                float globalZ = (j - (z_dimension - 1) / 2) * z_length;

                newBuilding.transform.position = new Vector3(globalX, 0, globalZ);

                int height = UnityEngine.Random.Range(1, 6) * 15;
                newBuilding.transform.localScale = new Vector3(1, (float) height, 1);

                GameObject newSidewalk = Instantiate(sidewalk);
                globalX = (i - (x_dimension - 1) / 2) * x_length;
                globalZ = (j - (z_dimension - 1) / 2) * z_length;

                newSidewalk.transform.position = new Vector3(globalX, 0, globalZ);
                newSidewalk.transform.localScale = new Vector3(x_length - road_width, 1, z_length - road_width);
            }
        }
    }
}
