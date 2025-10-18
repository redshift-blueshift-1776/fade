using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class YouAreTheMonsterText : MonoBehaviour
{
    public float x_speed;
    public float y_speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        x_speed = UnityEngine.Random.Range(-200f, 200f);
        y_speed = Mathf.Sqrt(200 * 200 - x_speed * x_speed);
        float rv = UnityEngine.Random.Range(0f, 1f);
        if (rv < 0.5f) {
            y_speed *= -1;
        }

       transform.position = new Vector3((x_speed > 0) ? 0 : 1999, (y_speed > 0) ? 0 : 1199, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(x_speed, y_speed, 0) * Time.deltaTime;
        if (Mathf.Abs(transform.position.x - 1920 / 2) > 1200) {
            Destroy(gameObject);
        }
        if (Mathf.Abs(transform.position.y - 1080 / 2) > 1000) {
            Destroy(gameObject);
        }
    }
}
