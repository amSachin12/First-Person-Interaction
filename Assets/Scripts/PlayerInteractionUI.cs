using UnityEngine;
using TMPro;

public class PlayerInteractionUI : MonoBehaviour
{
    public static PlayerInteractionUI instance;

    public TextMeshProUGUI interactionText;

    void Awake()
    {
        instance = this;
        interactionText.enabled = false;
    }

    public void ShowText(string msg)
    {
        interactionText.text = msg;
        interactionText.enabled = true;
    }

    public void HideText()
    {
        interactionText.text = string.Empty;
    }
}
