using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public GameObject textObject;
    [SerializeField] public TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine(DoTextStuff());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DoTextStuff() {
        float elapsed = 0f;
        Vector3 startPos = textObject.transform.position;
        while (true) {
            textObject.transform.position = startPos + new Vector3(0, 20 * Mathf.Sin(elapsed), 0);
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0.9f + 0.1f * Mathf.Cos(elapsed));
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
