using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class YouAreTheMonster : MonoBehaviour
{
    [SerializeField] public GameObject canvas;
    [SerializeField] public GameObject textBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTextBoxes());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnTextBoxes() {
        while (true) {
            GameObject tb = Instantiate(textBox);
            tb.transform.SetParent(canvas.transform);
            yield return new WaitForSeconds(1f);
        }
    }
}
