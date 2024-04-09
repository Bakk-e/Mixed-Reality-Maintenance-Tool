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
    public Button previousStep;
    public Button nextStep;
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
        //CenterOnButton(stepButtons[0].gameObject);
    }

    void StartButton()
    {
        infoScreen.SetActive(false);
        stepLayout.SetActive(true);
        steps[0].SetActive(true);
    }

    void Exit()
    {
        infoScreen.SetActive(true);
        stepLayout.SetActive(false);
        foreach (var step in steps)
        {
            step.SetActive(false);
        }
    }

    void Back()
    {
        RepairMenu.SetActive(true);   
        infoScreen.SetActive(false);
        this.gameObject.SetActive(false);
    }

    void Previous()
    {
    }

    void Next()
    {
    }

    void CreateButtons()
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

    void OnStepSelected(int stepIndex)
    {
        UpdateButtonStates(stepIndex);
        //CenterOnButton(stepButtons[stepIndex].gameObject);
        foreach (var step in steps)
        {
            step.SetActive(false);
        }
        steps[stepIndex].SetActive(true);
    }

    void UpdateButtonStates(int currentStepIndex)
    {
        for (int i = 0; i < stepButtons.Count; i++)
        {
            stepButtons[i].interactable = (i != currentStepIndex);
        }
    }

    void CenterOnButton(GameObject button)
    {
        Canvas.ForceUpdateCanvases();

        Vector2 viewportLocalPosition = scrollRect.viewport.localPosition;
        Vector2 buttonLocalPosition = button.transform.localPosition;

        float difference = viewportLocalPosition.x - buttonLocalPosition.x;

        contentPanel.localPosition = new Vector2(contentPanel.localPosition.x + difference, contentPanel.localPosition.y);
    }
}
