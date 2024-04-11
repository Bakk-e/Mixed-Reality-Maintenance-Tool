using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RepairStepScript : MonoBehaviour
{
    [Header("Step")]
    public GameObject thisStep;

    [Header("3D-Printer")]
    public List<GameObject> highlightableParts;

    public bool isStepActive;

 /*   public UnityEvent onStepEnd;

    public void OnStepBegin()
    { 
        foreach (var part in highlightableParts) 
        {
            part.SetActive(true);
        }
    }

    public void OnStepEnd()
    { 
        onStepEnd.Invoke();
        foreach(var part in highlightableParts) 
        { 
            part.SetActive(false); 
        }
    }*/


    // Start is called before the first frame update
    public void Start()
    {
        isStepActive = thisStep.activeSelf;
        if (isStepActive) 
        {
            foreach (var part in highlightableParts)
            {
                part.SetActive(true);
            }
        }
     
    }


    // Update is called once per frame
    void Update()
    {
        if (isStepActive && !thisStep.activeSelf)
        {
            End();
            isStepActive= false;
        }
        
    }


    public void End()
    {
        foreach (var part in highlightableParts)
        {
            part.SetActive(false);
        }
    }
}
