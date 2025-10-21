using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [Header("Page Setup")]
    [SerializeField] public GameObject[] pages;
    [SerializeField] public RectTransform pageContainer;
    [SerializeField] public float slideDuration = 0.5f;
    [SerializeField] public float pageWidth = 1920f;
    [SerializeField] public GameObject nextButton;
    [SerializeField] public GameObject previousButton;
    [SerializeField] public GameObject firstButton;
    [SerializeField] public GameObject lastButton;

    private int currentPage = 0;
    private bool isSliding = false;

    void Start()
    {
        previousButton.SetActive(false);
        nextButton.SetActive(true);
        for (int i = 0; i < pages.Length; i++)
        {
            RectTransform rt = pages[i].GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2((i - currentPage) * pageWidth, 0);
            pages[i].SetActive(i == currentPage || i == currentPage + 1 || i == currentPage - 1);
        }
    }
    private void Update()
    {
        if (pages.Length >= 3)
        {
            firstButton.SetActive(currentPage > 1);
            lastButton.SetActive(currentPage < pages.Length - 2);
        }
    }

    public void OnNextPage()
    {
        if (isSliding || currentPage >= pages.Length - 1) return;
        StartCoroutine(SlideToPage(currentPage + 1, false));
    }

    public void OnPrevPage()
    {
        if (isSliding || currentPage <= 0) return;
        StartCoroutine(SlideToPage(currentPage - 1, false));
    }

    public void OnFirstPage()
    {
        if (isSliding || currentPage == 0) return;
        StartCoroutine(SlideToPage(0, true));
    }

    public void OnLastPage()
    {
        if (isSliding || currentPage == pages.Length - 1) return;
        StartCoroutine(SlideToPage(pages.Length - 1, true));
    }
    private IEnumerator SlideToPage(int newPage, bool skipping)
    {
        isSliding = true;

        float elapsed = 0f;
        float direction = Mathf.Sign(newPage - currentPage);

        // Cache start positions for all active pages
        Vector2[] startPositions = new Vector2[pages.Length];
        for (int i = 0; i < pages.Length; i++)
        {
            RectTransform rt = pages[i].GetComponent<RectTransform>();
            startPositions[i] = rt.anchoredPosition;
            // Pre-activate neighbors so they slide in smoothly
            if (i == newPage || i == currentPage)
                pages[i].SetActive(true);
        }

        while (elapsed < slideDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.SmoothStep(0, 1, elapsed / slideDuration);

            for (int i = 0; i < pages.Length; i++)
            {
                RectTransform rt = pages[i].GetComponent<RectTransform>();
                rt.anchoredPosition = Vector2.Lerp(startPositions[i],
                    startPositions[i] - new Vector2(direction * pageWidth, 0), t);
            }

            yield return null;
        }

        // Snap to exact positions
        for (int i = 0; i < pages.Length; i++)
        {
            RectTransform rt = pages[i].GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2((i - newPage) * pageWidth, 0);
            // only keep visible ones active
            if (skipping)
            {
                pages[i].SetActive(true);
            }
            else
            {
                pages[i].SetActive(i == newPage || i == newPage + 1 || i == newPage - 1);
            }
        }

        currentPage = newPage;
        isSliding = false;
        previousButton.SetActive(currentPage > 0);
        nextButton.SetActive(currentPage < pages.Length - 1);
    }
}
