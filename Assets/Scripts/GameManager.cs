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
    private PlayerMovement playerMovement;
    HashSet<float[]> lightpoleGlobalPositions = new HashSet<float[]>();
    [SerializeField] private float energy = 100;
    [SerializeField] private float distanceThreshold = 10f;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        handleEnergy();
    }

    public void handleEnergy() {
        float distance = getDistanceToClosestLightpole();

        if (distance < distanceThreshold)
        {
            energy += 10 * Time.deltaTime / distance;
            energy = Mathf.Min(100, energy);
        }
        else
        {
            energy -= playerMovement.isBoosting ? 2 * Time.deltaTime : Time.deltaTime;
        }

    }

    //can not be called in Start, as generation might be finished after
    public void storeLightpoleGlobalPositions()
    {
        lightpoleGlobalPositions = cityGenerator.getLightpoleGlobalPositions();
        //debugLightpoleGlobalPositions();
    }

    private void debugLightpoleGlobalPositions()
    {
        foreach (float[] pos in lightpoleGlobalPositions)
        {
            Debug.Log(pos[0] + " " + pos[1] + " " + pos[2]);
        }
    }

    private float getDistanceToClosestLightpole()
    {
        float minDist = Mathf.Infinity;
        Vector3 playerPos = player.transform.position;
        
        foreach (float[] pos in lightpoleGlobalPositions)
        {
            Vector3 lightpolePos = new Vector3(pos[0], pos[1], pos[2]);
            float dist = (playerPos - lightpolePos).magnitude;
            minDist = Mathf.Min(dist, minDist);

            //tiny optimization
            if (minDist < distanceThreshold)
            {
                return minDist;
            }
        }
        return minDist;
    }
}
