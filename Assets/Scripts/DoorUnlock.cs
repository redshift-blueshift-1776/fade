using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class DoorUnlock : MonoBehaviour
{
    [SerializeField] public GameObject mainCamera;
    [SerializeField] public GameObject altCamera;
    [SerializeField] public GameObject door;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera.SetActive(true);
        altCamera.SetActive(false);
        unlockDoor();
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
        yield return null;
    }
}
