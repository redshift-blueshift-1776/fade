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
    [SerializeField] public GameObject roof;

    [Header("Hardcoded")]
    [SerializeField] public string[] hardcoded;

    [Header("Probabilities")]
    [SerializeField] public float p_flat_roof;
    [SerializeField] public float p_sloped_roof;
    [SerializeField] public float p_special_roof;

    public HashSet<int> hardcodedLocations;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ParseHardcoded();
        GenerateCity();
    }

    public void ParseHardcoded() {
        hardcodedLocations = new HashSet<int>();
        foreach (string s in hardcoded) {
            string[] parts = s.Split(',');
            int x_val = int.Parse(parts[0]);
            int z_val = int.Parse(parts[1]);
            hardcodedLocations.Add(z_dimension * x_val + z_val);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateBuilding(int i, int j) {
        GameObject newBuilding = Instantiate(building);
        float globalX = (i - (x_dimension - 1) / 2) * x_length;
        float globalZ = (j - (z_dimension - 1) / 2) * z_length;

        newBuilding.transform.position = new Vector3(globalX, 0, globalZ);

        int height = UnityEngine.Random.Range(1, 6) * 15;
        newBuilding.transform.localScale = new Vector3(x_length - road_width - 2 * sidewalk_width, (float) height, z_length - road_width - 2 * sidewalk_width);
    }

    public void GenerateRoofedBuilding(int i, int j) {
        GameObject newBuilding = Instantiate(building);
        float globalX = (i - (x_dimension - 1) / 2) * x_length;
        float globalZ = (j - (z_dimension - 1) / 2) * z_length;

        newBuilding.transform.position = new Vector3(globalX, 0, globalZ);

        int height = UnityEngine.Random.Range(1, 6) * 15;
        newBuilding.transform.localScale = new Vector3(x_length - road_width - 2 * sidewalk_width, (float) height, z_length - road_width - 2 * sidewalk_width);

        GameObject newRoof = Instantiate(roof);
        newRoof.transform.position = new Vector3(globalX, height, globalZ);
        newRoof.transform.localScale = 100f/12f * new Vector3(x_length - road_width - 2 * sidewalk_width, Mathf.Min(x_length - road_width - 2 * sidewalk_width, (z_length - road_width - 2 * sidewalk_width) / 2f), (z_length - road_width - 2 * sidewalk_width) / 2f);
    }

    public void GenerateCity() {
        for (int i = 0; i < x_dimension; i++) {
            for (int j = 0; j < z_dimension; j++) {
                if (!hardcodedLocations.Contains(z_dimension * i + j)) {
                    float rv = UnityEngine.Random.Range(0f, 1f);
                    if (rv < p_flat_roof) {
                        GenerateBuilding(i, j);
                    } else if (rv < p_flat_roof + p_sloped_roof) {
                        GenerateRoofedBuilding(i, j);
                    }
                }

                GameObject newSidewalk = Instantiate(sidewalk);
                float globalX = (i - (x_dimension - 1) / 2) * x_length;
                float globalZ = (j - (z_dimension - 1) / 2) * z_length;

                newSidewalk.transform.position = new Vector3(globalX, 0, globalZ);
                newSidewalk.transform.localScale = new Vector3(x_length - road_width, 1, z_length - road_width);

                GameObject newLightpole = Instantiate(lightpole);
                globalX = (i - (x_dimension - 1) / 2) * x_length + x_length / 2f - road_width / 2f - lightpole_edge_distance;
                globalZ = (j - (z_dimension - 1) / 2) * z_length + z_length / 2f - road_width / 2f - lightpole_edge_distance;
                newLightpole.transform.position = new Vector3(globalX, 0, globalZ);
                Streetlight sl = newLightpole.GetComponent<Streetlight>();
                sl.displacement = (i + j) % 4;

                GameObject newLightpole2 = Instantiate(lightpole);
                globalX = (i - (x_dimension - 1) / 2) * x_length - (x_length / 2f - road_width / 2f - lightpole_edge_distance);
                globalZ = (j - (z_dimension - 1) / 2) * z_length + z_length / 2f - road_width / 2f - lightpole_edge_distance;
                newLightpole2.transform.position = new Vector3(globalX, 0, globalZ);
                sl = newLightpole2.GetComponent<Streetlight>();
                sl.displacement = (i + j) % 4;

                GameObject newLightpole3 = Instantiate(lightpole);
                globalX = (i - (x_dimension - 1) / 2) * x_length + x_length / 2f - road_width / 2f - lightpole_edge_distance;
                globalZ = (j - (z_dimension - 1) / 2) * z_length - (z_length / 2f - road_width / 2f - lightpole_edge_distance);
                newLightpole3.transform.position = new Vector3(globalX, 0, globalZ);
                sl = newLightpole3.GetComponent<Streetlight>();
                sl.displacement = (i + j) % 4;

                GameObject newLightpole4 = Instantiate(lightpole);
                globalX = (i - (x_dimension - 1) / 2) * x_length - (x_length / 2f - road_width / 2f - lightpole_edge_distance);
                globalZ = (j - (z_dimension - 1) / 2) * z_length - (z_length / 2f - road_width / 2f - lightpole_edge_distance);
                newLightpole4.transform.position = new Vector3(globalX, 0, globalZ);
                sl = newLightpole4.GetComponent<Streetlight>();
                sl.displacement = (i + j) % 4;
            }
        }
    }
}
