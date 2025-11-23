using UnityEngine;

public class TVInteract : MonoBehaviour
{
    [Header("Screen Settings")]
    public Renderer screenRenderer;
    public Material[] screenMaterials;

    [Header("Audio Settings")]
    public AudioSource tvAudioSource;
    public AudioClip[] audioClips;

    [Header("Player Distance Settings")]
    public Transform player;
    public float hideDistance = 3f;

    bool isOn = false;
    bool isPlayerNear = false;

    void Start()
    {
        screenRenderer.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        isPlayerNear = true;

        PlayerInteractionUI.instance.ShowText("Press E to Turn ON/OFF TV");
    }

    void Update()
    {
        if (isPlayerNear)
        {
            float dist = Vector3.Distance(transform.position, player.position);

            // Hide UI if player walks away
            if (dist > hideDistance)
            {
                isPlayerNear = false;
                PlayerInteractionUI.instance.HideText();
                return;
            }

            // Interaction
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleTV();
                PlayerInteractionUI.instance.HideText();
            }
        }
    }

    void ToggleTV()
    {
        isOn = !isOn;

        if (isOn)
            TurnOnTV();
        else
            TurnOffTV();
    }

    void TurnOnTV()
    {
        screenRenderer.gameObject.SetActive(true);

        int index = Random.Range(0, screenMaterials.Length);

        screenRenderer.material = screenMaterials[index];
        tvAudioSource.clip = audioClips[index];

        tvAudioSource.Play();
    }

    void TurnOffTV()
    {
        tvAudioSource.Stop();
        screenRenderer.gameObject.SetActive(false);
    }
}
