using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStartUI : MonoBehaviour
{
    public GameObject defaultCamera;
    public GameObject fpsControllerScript;   // Your movement script

    public GameObject instructionsPanel;

    void Start()
    {
        // Pause player movement
        fpsControllerScript.SetActive(false);

        // Lock cursor off
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        instructionsPanel.SetActive(true);
    }

    public void OnClickOKButton()
    {
        defaultCamera.SetActive(false);
        instructionsPanel.SetActive(false);

        // Enable movement
        fpsControllerScript.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
