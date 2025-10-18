using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private City_Generator cityGenerator;
    [SerializeField] GameObject player;
    HashSet<float[]> lightpoleGlobalPositions = new HashSet<float[]>();
    private float energy = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
