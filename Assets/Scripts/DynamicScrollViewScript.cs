using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// #if UNITY_EDITOR
// using UnityEditor;
// #endif

public class DynamicScrollViewScript : MonoBehaviour
{
    [Header("Transform")]
    public Transform scrollViewContent;

    [Header("Button")]
    public GameObject prefab;

    [Header("UI Pages")]
    public GameObject repairMenu;
    public GameObject repairsScreen;
    public List<GameObject> repairs;

    [Header("Buttons")]
    public List<Button> returnButtons;


    void Start()
    {
        CreateButtons();

        foreach (var item in returnButtons) 
        {
            item.onClick.AddListener(EnableRepairMenu);
        }
    }

    private void CreateButtons()
    {
        foreach (GameObject repair in repairs) 
        {
            repair.SetActive(false);
            GameObject newButtonObj = Instantiate(prefab, scrollViewContent);
            Button newButton = newButtonObj.GetComponent<Button>();
            newButton.name = repair.name;
            if (newButton.TryGetComponent<ScrollViewItemScript>(out ScrollViewItemScript item)) {
                item.ChangeText(repair.name);
            }
            newButton.onClick.AddListener(() => EnableRepair(repair));
        }
    }

    private void EnableRepairMenu() 
    {
        foreach (GameObject repair in repairs)
        {
            repair.SetActive(false);
        }
        repairMenu.SetActive(true);
        repairsScreen.SetActive(false);
    }

    private void EnableRepair(GameObject repair) 
    {
        repairMenu.SetActive(false);
        repairsScreen.SetActive(true);
        repair.SetActive(true);
    }

    // #if UNITY_EDITOR
    //     private void OnValidate() 
    //     {
    //         createButtons();
    //     }
    // #endif
}
