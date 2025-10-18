using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private City_Generator cityGenerator;
    [SerializeField] GameObject player;
    [SerializeField] private Image energyBar;
    [SerializeField] private Image energyBarFill;
    private PlayerMovement pm;
    HashSet<float[]> lightpoleGlobalPositions = new HashSet<float[]>();
    [SerializeField] private float energy = 100;
    [SerializeField] private float distanceThreshold = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pm = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleEnergy();
    }

    public void HandleEnergy() {
        float distance = getDistanceToClosestLightpole();
        if (distance < distanceThreshold) {
            Debug.Log("Close to lightpole, charging");
            energy = Mathf.Min(100, energy + Time.deltaTime);
        } else {
            energy -= (pm.isBoosting ? 2 * Time.deltaTime : Time.deltaTime);
        }

    }

    //can not be called in Start, as generation might be finished after
    public void storeLightpoleGlobalPositions()
    {
        lightpoleGlobalPositions = cityGenerator.getLightpoleGlobalPositions();
        debugLightpoleGlobalPositions();
    }

    private void debugLightpoleGlobalPositions()
    {
        foreach (float[] pos in lightpoleGlobalPositions)
        {
            Debug.Log(pos[0] + " " + pos[1]);
        }
    }

    private float getDistanceToClosestLightpole()
    {
        float minDist = Mathf.Infinity;
        Vector3 playerPos = player.transform.position;

        foreach (float[] pos in lightpoleGlobalPositions)
        {
            float dist = Mathf.Sqrt(Mathf.Pow(pos[0], 2) + Mathf.Pow(pos[1], 2));
        }
        return minDist;
    }
}
