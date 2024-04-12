using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationRepairScript : MonoBehaviour
{
    [Header("ScrollRect")]
    public ScrollRect scrollRect;

    [Header("Prefabs")]
    public GameObject buttonPrefab;

    [Header("Repair Pages")]
    public GameObject RepairMenu;
    public GameObject infoScreen;
    public GameObject stepLayout;
    public List<GameObject> steps;

    [Header("Buttons")]
    public Button startRepair;
    public Button exit;
    public Button back;


    private List<Button> stepButtons = new List<Button>();
    private RectTransform contentPanel;


    void Start()
    {
        contentPanel = scrollRect.content;
        stepLayout.SetActive(false);
        CreateButtons();
        startRepair.onClick.AddListener(StartButton);
        exit.onClick.AddListener(Exit);
        back.onClick.AddListener(Back);
        UpdateButtonStates(0);
    }

    public void StartButton()
    {
        infoScreen.SetActive(false);
        stepLayout.SetActive(true);
        steps[0].SetActive(true);
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

    public void CreateButtons()
    {
        for (int index = 0; index < steps.Count; index++)
        {
            int localIndex = index;
            steps[index].SetActive(false);
            GameObject newButtonObj = Instantiate(buttonPrefab, contentPanel);
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
        if (steps[stepIndex] != null)
        {
            RepairStepScript currentStepScript = steps[stepIndex].GetComponent<RepairStepScript>();
            if (currentStepScript != null)
            {
                currentStepScript.End();
            }
        }

        UpdateButtonStates(stepIndex);
        foreach (var step in steps)
        {
            step.SetActive(false);
        }
        steps[stepIndex].SetActive(true);

        RepairStepScript newStepScript = steps[stepIndex].GetComponent<RepairStepScript>();
        if (newStepScript != null)
        {
            newStepScript.Start();
        }
    }

    public void UpdateButtonStates(int currentStepIndex)
    {
        for (int i = 0; i < stepButtons.Count; i++)
        {
            stepButtons[i].interactable = (i != currentStepIndex);
        }
    }
}
