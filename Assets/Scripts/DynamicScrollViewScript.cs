using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// #if UNITY_EDITOR
// using UnityEditor;
// #endif

public class DynamicScrollViewScript : MonoBehaviour
{
    [SerializeField]
    private Transform scrollViewContent;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private List<string> buttonTitles;

    void Start()
    {
        createButtons();
    }

    private void createButtons()
    {
        foreach (string title in buttonTitles) {
            GameObject newButton = Instantiate(prefab, scrollViewContent);
            newButton.name = title;
            if (newButton.TryGetComponent<ScrollViewItemScript>(out ScrollViewItemScript item)) {
                item.ChangeText(title);
            }
        }
    }

    // #if UNITY_EDITOR
    //     private void OnValidate() 
    //     {
    //         createButtons();
    //     }
    // #endif
}
