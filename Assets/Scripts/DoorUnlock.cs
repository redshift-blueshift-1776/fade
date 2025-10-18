using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class DoorUnlock : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] public GameObject mainCamera;
    [SerializeField] public GameObject altCamera;
    [SerializeField] public GameObject door;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float targetReflectionIntensity;
    public Color targetAmbientColor;

    [SerializeField] private DoorColor doorColor;
    public enum DoorColor
    {
        RED, ORANGE, YELLOW, GREEN, BLUE, PURPLE
    }
    void Start()
    {
        mainCamera.SetActive(true);
        altCamera.SetActive(false);
        unlockDoor();
        targetReflectionIntensity = RenderSettings.reflectionIntensity;
        targetAmbientColor = RenderSettings.ambientSkyColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void unlockDoor() {
        StartCoroutine(doorAnimation());
    }

    public IEnumerator doorAnimation() {
        yield return new WaitForSeconds(2f);
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
        while (elapsed < duration) {
            door.transform.position = Vector3.Lerp(startPos, targetPos, elapsed/duration);
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
}
