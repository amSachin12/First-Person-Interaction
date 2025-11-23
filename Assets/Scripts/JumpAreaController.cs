using UnityEngine;
using TMPro;

public class JumpAreaController : MonoBehaviour
{
    public GameObject jumpUI;              // World space UI on wall
    public TextMeshProUGUI counterText;    // Jump count text
    public Transform player;
    public Transform playerCam;
    public MonoBehaviour fpsController;    // Your movement script
    public float faceSpeed = 5f;

    int jumpCount = 0;
    bool inJumpArea = false;
    bool facingWall = false;

    void Start()
    {
        jumpUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        inJumpArea = true;

        // Disable full controls (movement + look)
        FPSController.freezeMovement = true;
        FPSController.allowJumpOnly = true;


        // Activate Jump UI
        jumpUI.SetActive(true);

        // Force player to face the wall
        facingWall = true;

        // Reset UI text
        counterText.text = "Jump Counter = 0";
    }

    void Update()
    {
        if (!inJumpArea) return;

        // Rotate player slowly to face the UI
        if (facingWall)
        {
            Vector3 dir = jumpUI.transform.position - player.position;
            dir.y = 0;

            Quaternion targetRot = Quaternion.LookRotation(dir);
            player.rotation = Quaternion.Lerp(player.rotation, targetRot, Time.deltaTime * faceSpeed);

            if (Quaternion.Angle(player.rotation, targetRot) < 2f)
            {
                facingWall = false;
            }
        }

        // Allow actual gameplay jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpCount++;
            counterText.text = "Jump Counter = " + jumpCount;
        }
    }

}
