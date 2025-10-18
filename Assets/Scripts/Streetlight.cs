using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streetlight : MonoBehaviour
{
    public int displacement;

    public float secondsPerBeat;

    public float tempo;

    public double nextChangeTime;

    public int lastColorBeat = -1;

    private Color emissionColor = new Color(191, 61, 0, 255);

    [SerializeField] public GameObject lightCube;
    [SerializeField] public Color bright_color;
    [SerializeField] public Color dark_color;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextChangeTime = BeatManager.Instance.GetNextBeatTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (!BeatManager.Instance.audioSource.isPlaying) return;

        int currentBeat = BeatManager.Instance.GetCurrentBeatNumber();

        if (currentBeat != lastColorBeat)
        {
            // Debug.Log("New Color Beat");
            lastColorBeat = currentBeat;
            if (currentBeat % 4 == displacement) {
                // Debug.Log("Flashing Color");
                StartCoroutine(FlashColor());
            }
        }
    }

    public IEnumerator FlashColor() {
        float elapsed = 0f;
        float duration = 3 * (float)BeatManager.Instance.GetSecondsPerBeat();
        Renderer targetRenderer = lightCube.GetComponent<Renderer>();
        while (elapsed < duration) {
            float t = elapsed / duration;
            // lightCube.GetComponent<MeshRenderer>().material.color = Color.Lerp(bright_color, dark_color, t);
            Material material = targetRenderer.material;
            material.EnableKeyword("_EMISSION");
            material.SetColor("_EmissionColor", Color.Lerp(emissionColor, Color.black, t));
            elapsed += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
