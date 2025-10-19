using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneChanger : MonoBehaviour
{

    public void LoadPreviousLevel() {
        int n = PlayerPrefs.GetInt("PreviousLevel", 1);
        SceneManager.LoadSceneAsync(n);
    }

    public void LoadSceneByNumber(int num) {
        SceneManager.LoadSceneAsync(num);
    }
}
