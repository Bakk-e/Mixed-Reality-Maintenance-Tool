using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// #if UNITY_EDITOR
// using UnityEditor;
// #endif

public class NavigationRepairScript : MonoBehaviour
{
    [Header("Transform")]
    public Transform scrollViewContent;

    [Header("Prefabs")]
    public GameObject buttonPrefab;

    [Header("Repair Pages")]
    public GameObject RepairMenu;
    public GameObject infoScreen;
    public GameObject stepLayout;
    public List<GameObject> steps;

    [Header("Buttons")]
    public Button startRepair;
    public Button previousStep;
    public Button nextStep;
    public Button exit;
    public Button back;

    [Header("Other")]
    public List<GameObject> stepArrows;

    private List<Button> stepButtons = new List<Button>();
    private int stepAmount = 0;


    void Start()
    {
        stepLayout.SetActive(false);
        CreateButtons();
        startRepair.onClick.AddListener(StartButton);
        exit.onClick.AddListener(Exit);
        //back.onClick.AddListener(Back);
        previousStep.onClick.AddListener(Previous);
        nextStep.onClick.AddListener(Next);
        UpdateButtonStates(0);
        previousStep.interactable = false;
    }

    public void StartButton()
    {
        infoScreen.SetActive(false);
        stepLayout.SetActive(true);
        steps[0].SetActive(true);
        // stepArrows[0].SetActive(true);
    }

    public void Exit()
    {
        infoScreen.SetActive(true);
        stepLayout.SetActive(false);
        foreach (var step in steps)
        {
            step.SetActive(false);
        }
    }

    public void Back()
    {
        RepairMenu.SetActive(true);   
        infoScreen.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void Previous()
    {
        if (stepAmount <= -1) 
        {
            previousStep.interactable = false;
            return;
        }
        if (stepAmount - 1 == 0) 
        {
            previousStep.interactable = false;
        }
        if (stepAmount > 0) 
        {
            stepAmount -= 1;
        }
        OnStepSelected(stepAmount);
        if (!nextStep.interactable) 
        {
            nextStep.interactable = true;
        }
    }

    public void Next()
    {
        if (stepAmount >= steps.Count - 1)
        {
            nextStep.interactable = false;
            return;
        }

        Debug.Log($"Before incrementing, stepAmount is: {stepAmount}");
        stepAmount++;
        Debug.Log($"After incrementing, stepAmount is: {stepAmount}");

        OnStepSelected(stepAmount);

        previousStep.interactable = true;

        if (stepAmount == steps.Count - 1)
        {
            nextStep.interactable = false;
        }
    }

    public void CreateButtons()
    {
        for (int index = 0; index < steps.Count; index++)
        {
            int localIndex = index;
            steps[index].SetActive(false);
            GameObject newButtonObj = Instantiate(buttonPrefab, scrollViewContent);
            Button newButton = newButtonObj.GetComponent<Button>();
            string stepNum = $"{index + 1}";
            newButton.name = stepNum;
            if (newButton.TryGetComponent<ScrollViewItemScript>(out ScrollViewItemScript item)) {
                item.ChangeText(stepNum);
            }
            newButton.onClick.AddListener(() => OnStepSelected(localIndex));
            stepButtons.Add(newButton);
        }
    }

    public void OnStepSelected(int stepIndex)
    {
        UpdateButtonStates(stepIndex);
        foreach (var step in steps)
        {
            step.SetActive(false);
        }
        // foreach (var arrow in stepArrows)
        // {
        //     arrow.SetActive(false);
        // }
        steps[stepIndex].SetActive(true);
        // stepArrows[stepIndex].SetActive(true);
        stepAmount = stepIndex;
    }

    public void UpdateButtonStates(int currentStepIndex)
    {
        for (int i = 0; i < stepButtons.Count; i++)
        {
            stepButtons[i].interactable = (i != currentStepIndex);
        }
    }

    // #if UNITY_EDITOR
    //     private void OnValidate() 
    //     {
    //         CreateButtons();
    //     }
    // #endif
}
