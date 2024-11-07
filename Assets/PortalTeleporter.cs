using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleporter : MonoBehaviour
{
    [SerializeField] private PortalActivator portalActivator;
    [SerializeField] private AudioSource teleportAudioSource;
    [SerializeField] private string nextLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player") || !portalActivator.IsActivated) return;
        
        teleportAudioSource.Play();
        SceneManager.LoadScene(nextLevel);
    }
}
