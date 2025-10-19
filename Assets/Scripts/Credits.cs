using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] public TMP_Text quoteText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        quoteText.text = "";
        StartCoroutine(DoCredits());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DoCredits(){
        float startAlpha = quoteText.color.a;
        float targetAlpha = 0f;
        yield return new WaitForSeconds(1f);
        float elapsed = 0f;
        float duration = 3f;
        while (elapsed < duration) {
            float t = elapsed / duration;

            string chars = "I'm Faded...";
            int numChars = (int) (chars.Length * t);
            string charsToPut = chars.Substring(0, numChars);
            quoteText.text = charsToPut;
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.text = "I'm Faded...";
        yield return new WaitForSeconds(0.5f);

        duration = 3f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, targetAlpha);
        quoteText.text = "";

        duration = 1f;
        elapsed = 0f;
        quoteText.text = "<u>Fade</u>";
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, 1f-t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, 1f);
        duration = 2f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;

            string chars = "<u>Fade</u>\nA Game By Spectre Games";
            int numChars = 11 + (int) ((chars.Length - 11) * t);
            string charsToPut = chars.Substring(0, numChars);
            quoteText.text = charsToPut;
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.text = "<u>Fade</u>\nA Game By Spectre Games";
        yield return new WaitForSeconds(0.5f);

        duration = 3f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, targetAlpha);
        quoteText.text = "";
        
        duration = 1f;
        elapsed = 0f;
        quoteText.text = "<u>Game Concept</u>";
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, 1f-t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, 1f);
        duration = 2f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;

            string chars = "<u>Game Concept</u>\nForest Ho-Chen";
            int numChars = 19 + (int) ((chars.Length - 19) * t);
            string charsToPut = chars.Substring(0, numChars);
            quoteText.text = charsToPut;
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.text = "<u>Game Concept</u>\nForest Ho-Chen";
        yield return new WaitForSeconds(0.5f);

        duration = 3f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, targetAlpha);
        quoteText.text = "";

        duration = 1f;
        elapsed = 0f;
        quoteText.text = "<u>Programming</u>";
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, 1f-t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, 1f);
        duration = 2f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;

            string chars = "<u>Programming</u>\nJustin Zou and Forest Ho-Chen";
            int numChars = 18 + (int) ((chars.Length - 18) * t);
            string charsToPut = chars.Substring(0, numChars);
            quoteText.text = charsToPut;
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.text = "<u>Programming</u>\nJustin Zou and Forest Ho-Chen";
        yield return new WaitForSeconds(0.5f);

        duration = 3f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, targetAlpha);
        quoteText.text = "";

        duration = 1f;
        elapsed = 0f;
        quoteText.text = "<u>3D Modelling</u>";
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, 1f-t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, 1f);
        duration = 2f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;

            string chars = "<u>3D Modelling</u>\nHelen Liu and Forest Ho-Chen";
            int numChars = 19 + (int) ((chars.Length - 19) * t);
            string charsToPut = chars.Substring(0, numChars);
            quoteText.text = charsToPut;
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.text = "<u>3D Modelling</u>\nHelen Liu and Forest Ho-Chen";
        yield return new WaitForSeconds(0.5f);

        duration = 3f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, targetAlpha);
        quoteText.text = "";

        duration = 1f;
        elapsed = 0f;
        quoteText.text = "<u>Story</u>";
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, 1f-t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, 1f);
        duration = 2f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;

            string chars = "<u>Story</u>\nHelen Liu and Forest Ho-Chen";
            int numChars = 12 + (int) ((chars.Length - 12) * t);
            string charsToPut = chars.Substring(0, numChars);
            quoteText.text = charsToPut;
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.text = "<u>Story</u>\nHelen Liu and Forest Ho-Chen";
        yield return new WaitForSeconds(0.5f);

        duration = 3f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, targetAlpha);
        quoteText.text = "";
        
        duration = 1f;
        elapsed = 0f;
        quoteText.text = "<u>Level Design</u>";
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, 1f-t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, 1f);
        duration = 2f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;

            string chars = "<u>Level Design</u>\nJustin Zou and Forest Ho-Chen";
            int numChars = 19 + (int) ((chars.Length - 19) * t);
            string charsToPut = chars.Substring(0, numChars);
            quoteText.text = charsToPut;
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.text = "<u>Level Design</u>\nJustin Zou and Forest Ho-Chen";
        yield return new WaitForSeconds(0.5f);

        duration = 3f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, targetAlpha);
        quoteText.text = "";

        duration = 1f;
        elapsed = 0f;
        quoteText.text = "<u>Music</u>";
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, 1f-t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, 1f);
        duration = 2f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;

            string chars = "<u>Music</u>\nForest Ho-Chen";
            int numChars = 12 + (int) ((chars.Length - 12) * t);
            string charsToPut = chars.Substring(0, numChars);
            quoteText.text = charsToPut;
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.text = "<u>Music</u>\nForest Ho-Chen";
        yield return new WaitForSeconds(0.5f);

        duration = 3f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, targetAlpha);
        quoteText.text = "";
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, 1f);

        duration = 3f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;

            string chars = "Don't let them tell you how you should feel...";
            int numChars = (int) (chars.Length * t);
            string charsToPut = chars.Substring(0, numChars);
            quoteText.text = charsToPut;
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.text = "Don't let them tell you how you should feel...";
        yield return new WaitForSeconds(0.5f);

        duration = 3f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, targetAlpha);
        quoteText.text = "";
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, 1f);

        duration = 3f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;

            string chars = "Even if they say you are the monster...";
            int numChars = (int) (chars.Length * t);
            string charsToPut = chars.Substring(0, numChars);
            quoteText.text = charsToPut;
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.text = "Even if they say you are the monster...";
        yield return new WaitForSeconds(0.5f);

        duration = 3f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, targetAlpha);
        quoteText.text = "";
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, 1f);

        duration = 3f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;

            string chars = "Thanks for playing!";
            int numChars = (int) (chars.Length * t);
            string charsToPut = chars.Substring(0, numChars);
            quoteText.text = charsToPut;
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.text = "Thanks for playing!";
        yield return new WaitForSeconds(0.5f);

        duration = 3f;
        elapsed = 0f;
        while (elapsed < duration) {
            float t = elapsed / duration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, currentAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, targetAlpha);
        quoteText.text = "";
        quoteText.color = new Color(quoteText.color.r, quoteText.color.g, quoteText.color.b, 1f);
        yield return new WaitForSeconds(1f);
        quoteText.text = "";
        SceneManager.LoadScene(0);
    }
}
