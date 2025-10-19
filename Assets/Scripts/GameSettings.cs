using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    public GameObject settings;
    public GameObject homePage;
    public GameObject mouseSettingsPage;
    public GameObject videoSettingsPage;

    private bool inSettings;
    private bool gameEnded;
    private Stack<string> settingStack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inSettings = false;
        gameEnded = false;
        settingStack = new Stack<string>();
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
