using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public static bool hasKey = false;

    [Header("Player Settings")]
    public Transform player;
    public float hideDistance = 3f;

    bool isPlayerNear = false;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        isPlayerNear = true;

        PlayerInteractionUI.instance.ShowText("Press E to Pick Key");
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            hasKey = true;

            gameObject.SetActive(false); // Hide key mesh

            PlayerInteractionUI.instance.HideText();

            isPlayerNear = false;
        }
    }
}
