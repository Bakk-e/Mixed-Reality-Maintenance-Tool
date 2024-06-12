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
    public GameObject repairMenu;
    public GameObject settingsMenu;
    public GameObject repairsScreen;

    [Header("Main Menu Buttons")]
    public Button repairButton;
    public Button settingsButton;
    public Button quitButton;

    public List<Button> returnButtons;

    
    void Start()
    {
        EnableMainMenu();

        repairButton.onClick.AddListener(Repair);
        settingsButton.onClick.AddListener(EnableSettings);
        quitButton.onClick.AddListener(Quit);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
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
        mainMenu.SetActive(false);
        repairMenu.SetActive(true);
        settingsMenu.SetActive(false);
        repairsScreen.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        repairMenu.SetActive(false);
        settingsMenu.SetActive(false);
        repairsScreen.SetActive(false);
    }

    public void EnableSettings()
    {
    /*    mainMenu.SetActive(false);
        repairMenu.SetActive(false);
        settingsMenu.SetActive(true);
        repairsScreen.SetActive(false);*/
        //Quit();
    }
}
