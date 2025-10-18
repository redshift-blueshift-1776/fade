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
            lastColorBeat = currentBeat;
            StartCoroutine(FlashColor());
        }
    }

    public IEnumerator FlashColor() {
        float elapsed = 0f;
        float duration = 3 * (float) BeatManager.Instance.GetSecondsPerBeat();
        while (elapsed < duration) {
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
