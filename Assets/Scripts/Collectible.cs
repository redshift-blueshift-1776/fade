using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Collectible : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioManager audioManager;

    private AudioSource audioSource;
    private float clipLength;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clipLength = audioSource.clip.length;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.collectedCollectible();
            gameObject.SetActive(false);
            audioManager.playSound("pickupCollectible");
        }
    }
    
    private IEnumerator handleSound()
    {
        float t = 0;
        float cooldownTimer;

        while (true)
        {
            float distance = (player.transform.position - transform.position).magnitude;
            cooldownTimer = Mathf.Clamp(0.025f * distance, clipLength, 5f);
            if (t < cooldownTimer)
            {
                t += Time.deltaTime;
            } else
            {
                audioSource.Play();
                t = 0;
            }
            yield return null;
        }
    }
}
