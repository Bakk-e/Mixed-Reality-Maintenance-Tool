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

    [Header("Prefabs")]
    public GameObject buttonPrefab;

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
        for (int index = 0; index < repairs.Count; index++) 
        {
            GameObject localRepair = repairs[index];
            int localIndex = index;
            localRepair.SetActive(false);
            GameObject newButtonObj = Instantiate(buttonPrefab, scrollViewContent);
            Button newButton = newButtonObj.GetComponent<Button>();
            string repairTitle = localRepair.name;
            newButton.name = repairTitle;
            if (newButton.TryGetComponent<ScrollViewItemScript>(out ScrollViewItemScript item)) {
                item.ChangeText(repairTitle);
            }
            newButton.onClick.AddListener(() => EnableRepair(localIndex));
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

    private void EnableRepair(int currentIndex) 
    {
        repairMenu.SetActive(false);
        repairsScreen.SetActive(true);
        repairs[currentIndex].SetActive(true);
    }

    // #if UNITY_EDITOR
    //     private void OnValidate() 
    //     {
    //         CreateButtons();
    //     }
    // #endif
}
