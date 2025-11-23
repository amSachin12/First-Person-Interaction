using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    public Transform doorPivot;

    [Header("Player Settings")]
    public Transform player;
    public float hideDistance = 3f;

    bool isOpen = false;
    bool isPlayerNear = false;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        isPlayerNear = true;

        if (KeyPickup.hasKey)
            PlayerInteractionUI.instance.ShowText("Press E to Open/Close Door");
        else
            PlayerInteractionUI.instance.ShowText("Find the key to open door");
    }

    void Update()
    {
        if (!isPlayerNear) return;

        float dist = Vector3.Distance(transform.position, player.position);

        if (dist > hideDistance)
        {
            isPlayerNear = false;
            PlayerInteractionUI.instance.HideText();
            return;
        }

        if (KeyPickup.hasKey && Input.GetKeyDown(KeyCode.E))
        {
            ToggleDoor();
            PlayerInteractionUI.instance.HideText();
        }
    }

    void ToggleDoor()
    {
        isOpen = !isOpen;

        float angle = isOpen ? 90f : 0f;

        doorPivot.localRotation = Quaternion.Euler(0, angle, 0);
    }
}
