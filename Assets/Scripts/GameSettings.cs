using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSettings : MonoBehaviour
{
    public GameObject settings;
    public GameObject homePage;
    public GameObject mouseSettingsPage;
    public GameObject videoSettingsPage;
    public GameObject audioSettingsPage;
    public Slider audioSlider;
    public TMP_Text audioText;

    private bool inSettings;
    private bool gameEnded;
    private Stack<string> settingStack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inSettings = false;
        gameEnded = false;
        settingStack = new Stack<string>();

        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 0.5f);
        }
        audioSlider.value = PlayerPrefs.GetFloat("volume");
        audioText.text = AudioListener.volume.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        handleEmergencyExit();
        if (gameEnded)
        {
            settingStack.Clear();
            inSettings = false;
            setPage();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!inSettings)
            {
                settingStack.Push("Home");
            } else
            {
                settingStack.Pop();
            }
        }

        setPage();

        PlayerPrefs.SetFloat("volume", audioSlider.value);
        AudioListener.volume = audioSlider.value;
        audioText.text = Mathf.Ceil(AudioListener.volume * 100f).ToString() + "%";
    }

    public bool getGameEnded()
    {
        return gameEnded;
    }

    public void setGameEnded(bool b)
    {
        gameEnded = b;
    }

    private void disableAllPages()
    {
        homePage.SetActive(false);
        mouseSettingsPage.SetActive(false);
        videoSettingsPage.SetActive(false);
        audioSettingsPage.SetActive(false); 
    }

    private void setPage()
    {
        if (settingStack.Count == 0)
        {
            inSettings = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            AudioListener.pause = false;
            Time.timeScale = 1f;
        } else
        {
            inSettings = true;
            AudioListener.pause = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            string page = settingStack.Peek();
            switch (page)
            {
                case "Home":
                    disableAllPages();
                    homePage.SetActive(true);
                    break;
                case "Mouse":
                    disableAllPages();
                    mouseSettingsPage.SetActive(true);
                    break;
                case "Video":
                    disableAllPages();
                    videoSettingsPage.SetActive(true);
                    break;
                case "Audio":
                    disableAllPages();
                    audioSettingsPage.SetActive(true);
                    break;
                default:
                    disableAllPages();
                    homePage.SetActive(true);
                    break;
            }
            Time.timeScale = 0f;
        }
        settings.SetActive(inSettings);
    }

    public bool isInSettings()
    {
        return inSettings;
    }

    public void addPage(string page)
    {
        settingStack.Push(page);
    }

    private void handleEmergencyExit()
    {
        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.M))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            loadScene("Main Menu");
        } 
    }

    public void loadScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }

    public void loadScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }
}
