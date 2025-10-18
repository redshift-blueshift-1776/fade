using UnityEngine;
// using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;
// using TMPro;
using UnityEngine.SceneManagement;

public class City_Generator : MonoBehaviour
{
    [Header("Dimensions")]
    [SerializeField] public int x_dimension; // Should be an odd number
    [SerializeField] public int z_dimension; // Should be an odd number
    [SerializeField] public float x_length;
    [SerializeField] public float z_length;
    [SerializeField] public float sidewalk_width;
    [SerializeField] public float road_width;
    [SerializeField] public float lightpole_edge_distance;

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
                newBuilding.transform.localScale = new Vector3(x_length - road_width - 2 * sidewalk_width, (float) height, z_length - road_width - 2 * sidewalk_width);

                GameObject newSidewalk = Instantiate(sidewalk);
                globalX = (i - (x_dimension - 1) / 2) * x_length;
                globalZ = (j - (z_dimension - 1) / 2) * z_length;

                newSidewalk.transform.position = new Vector3(globalX, 0, globalZ);
                newSidewalk.transform.localScale = new Vector3(x_length - road_width, 1, z_length - road_width);

                GameObject newLightpole = Instantiate(lightpole);
                globalX = (i - (x_dimension - 1) / 2) * x_length + x_length / 2f - road_width / 2f - lightpole_edge_distance;
                globalZ = (j - (z_dimension - 1) / 2) * z_length + z_length / 2f - road_width / 2f - lightpole_edge_distance;
                newLightpole.transform.position = new Vector3(globalX, 0, globalZ);

                GameObject newLightpole2 = Instantiate(lightpole);
                globalX = (i - (x_dimension - 1) / 2) * x_length - (x_length / 2f - road_width / 2f - lightpole_edge_distance);
                globalZ = (j - (z_dimension - 1) / 2) * z_length + z_length / 2f - road_width / 2f - lightpole_edge_distance;
                newLightpole2.transform.position = new Vector3(globalX, 0, globalZ);

                GameObject newLightpole3 = Instantiate(lightpole);
                globalX = (i - (x_dimension - 1) / 2) * x_length + x_length / 2f - road_width / 2f - lightpole_edge_distance;
                globalZ = (j - (z_dimension - 1) / 2) * z_length - (z_length / 2f - road_width / 2f - lightpole_edge_distance);
                newLightpole3.transform.position = new Vector3(globalX, 0, globalZ);

                GameObject newLightpole4 = Instantiate(lightpole);
                globalX = (i - (x_dimension - 1) / 2) * x_length - (x_length / 2f - road_width / 2f - lightpole_edge_distance);
                globalZ = (j - (z_dimension - 1) / 2) * z_length - (z_length / 2f - road_width / 2f - lightpole_edge_distance);
                newLightpole4.transform.position = new Vector3(globalX, 0, globalZ);
            }
        }
    }
}
