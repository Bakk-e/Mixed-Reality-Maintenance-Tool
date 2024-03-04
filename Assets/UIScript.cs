using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIScript : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject settings;

    [Header("Main Menu Buttons")]
    public Button repairButton;
    public Button settingsButton;
    public Button quitButton;

    //public List<Button> returnButtons;

    
    void Start()
    {
        EnableMainMenu();

        repairButton.onClick.AddListener(Repair);
        settingsButton.onClick.AddListener(EnableSettings);
        quitButton.onClick.AddListener(Quit);
    }

    public void Quit() 
    {
        Application.Quit();

        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #endif
    }

    public void Repair() 
    {
        //Add code to switch to new menu with list of repairs
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void EnableSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }
}
