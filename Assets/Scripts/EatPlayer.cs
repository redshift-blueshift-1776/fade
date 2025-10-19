using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class EatPlayer : MonoBehaviour
{
    [SerializeField] public GameObject arm;
    [SerializeField] public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GrabAndEat());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GrabAndEat() {
        yield return new WaitForSeconds(1f);
        float elapsed = 0f;
        float duration = 2f;
        Quaternion startRot = arm.transform.localRotation;
        Quaternion targetRot = Quaternion.Euler(0,0,0);
        while (elapsed < duration) {
            arm.transform.localRotation = Quaternion.Slerp(startRot, targetRot, elapsed/duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        arm.transform.localRotation = targetRot;
        yield return new WaitForSeconds(1f);
        elapsed = 0f;
        duration = 3f;
        player.transform.SetParent(arm.transform);
        Vector3 startPos = arm.transform.position;
        Vector3 targetPos = arm.transform.position + new Vector3(0, 0, -50);
        while (elapsed < duration) {
            arm.transform.position = Vector3.Lerp(startPos, targetPos, elapsed/duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(9);
        yield return null;
    }
}
