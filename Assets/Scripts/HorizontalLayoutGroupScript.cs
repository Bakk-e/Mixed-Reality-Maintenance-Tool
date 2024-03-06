using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class HorizontalLayoutGroupScript : MonoBehaviour
{
    public float leftPadding = 0.09f;
    public float rightPadding = 0.55f;
    public float spacing = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        LayoutElements();
    }

    private void LayoutElements()
    {
        RectTransform parentRectTransform = GetComponent<RectTransform>();
        float totalWidth = parentRectTransform.rect.width - (leftPadding + rightPadding);
        float currentX = leftPadding;

        float actualSpacing = totalWidth * spacing;

        for (int i = 0; i < transform.childCount; i++)
        {
            RectTransform child = transform.GetChild(i) as RectTransform;
            if (!child.gameObject.activeSelf) continue;

            float childWidth = child.rect.width;
            float childHeight = child.rect.height;

            child.anchoredPosition = new Vector2(currentX, (parentRectTransform.rect.height - childHeight) / 2);

            currentX += childWidth + actualSpacing;
        }
    }

    #if UNITY_EDITOR
        private void OnValidate()
        {
            LayoutElements();
        }
    #endif
}
