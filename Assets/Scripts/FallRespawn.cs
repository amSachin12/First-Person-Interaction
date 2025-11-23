using UnityEngine;

public class FallRespawn : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController cc = other.GetComponent<CharacterController>();

            // Disable controller for teleport
            cc.enabled = false;
            other.transform.position = respawnPoint.position;
            other.transform.rotation = respawnPoint.rotation;
            cc.enabled = true;
        }
    }
}
