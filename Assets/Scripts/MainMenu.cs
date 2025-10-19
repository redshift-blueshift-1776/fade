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

    private RectTransform textRectTransform;
    private Vector2 startAnchoredPos;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        textRectTransform = textObject.GetComponent<RectTransform>();
        startAnchoredPos = textRectTransform.anchoredPosition;

        StartCoroutine(DoTextStuff());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.C))
        {
            SceneManager.LoadScene(21);
        } 
    }

    public IEnumerator DoTextStuff() {
        float elapsed = 0f;
        while (true) {
            textRectTransform.anchoredPosition = startAnchoredPos + new Vector2(0, 20f * Mathf.Sin(elapsed));
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0.9f + 0.1f * Mathf.Cos(elapsed));
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
