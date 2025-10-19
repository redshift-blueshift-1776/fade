using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.AI;

public class DoorUnlock : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject altCamera;
    [SerializeField] private GameObject door;

    [SerializeField] private GameObject key;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float targetReflectionIntensity;
    private Color targetAmbientColor;

    public Color doorColor;

    private Material doorMaterial;

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        
        mainCamera.SetActive(true);
        altCamera.SetActive(false);

        targetReflectionIntensity = RenderSettings.reflectionIntensity;
        targetAmbientColor = RenderSettings.ambientSkyColor;

        doorMaterial = door.GetComponent<MeshRenderer>().material;

        // Iterate through each immediate child Transform
    }

    private void updateColor()
    {
        if (doorMaterial == null)
        {
            doorMaterial = door.GetComponent<MeshRenderer>().material;
        }
    
        foreach (Transform block in key.transform)
        {
            // Add the child's GameObject to the list
            GameObject child = block.gameObject;
            Material blockMaterial = child.GetComponent<MeshRenderer>().material;
            blockMaterial.color = doorColor;
            blockMaterial.EnableKeyword("_EMISSION");
            blockMaterial.SetColor("_EmissionColor", doorColor);
        }

        doorMaterial.color = doorColor;
        doorMaterial.SetColor("_Color", doorColor);
        doorMaterial.EnableKeyword("_EMISSION");
        doorMaterial.SetColor("_EmissionColor", doorColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void unlockDoor() {
        StartCoroutine(doorAnimation(0));
    }

    public IEnumerator doorAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameManager.setIsInCutscene(true);
        RenderSettings.reflectionIntensity = 1.0f;
        RenderSettings.ambientIntensity = 0.3f;
        RenderSettings.ambientSkyColor = Color.white;
        mainCamera.SetActive(false);
        altCamera.SetActive(true);
        float duration = 3f;
        float elapsed = 0f;
        Vector3 startPos = door.transform.position;
        Vector3 targetPos = door.transform.position + new Vector3(0, -30, 0);
        while (elapsed < duration)
        {
            door.transform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        door.transform.position = targetPos;
        mainCamera.SetActive(true);
        altCamera.SetActive(false);
        RenderSettings.reflectionIntensity = targetReflectionIntensity;
        RenderSettings.ambientIntensity = 0;
        RenderSettings.ambientSkyColor = targetAmbientColor;
        gameManager.setIsInCutscene(false);
        yield return null;
    }

    public void setColor(Color c)
    {
        doorColor = c;
        updateColor();
    }
}
