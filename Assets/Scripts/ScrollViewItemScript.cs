using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ScrollViewItemScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI buttonText;

    public void ChangeText(string text) {
        buttonText.text = text;
    }
}
