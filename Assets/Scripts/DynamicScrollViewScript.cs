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
    private int buttons;

    void Start()
    {
        createButtons();
    }

    private void createButtons()
    {
        for (int i = 0; i < buttons; i++)
        {
            GameObject newButton = Instantiate(prefab, scrollViewContent);
            newButton.name = "Button " + (i + 1);
            if (newButton.TryGetComponent<ScrollViewItemScript>(out ScrollViewItemScript item)) {

                item.ChangeText("" + (i + 1));
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
