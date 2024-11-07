using UnityEngine;

public class PortalActivator : MonoBehaviour
{
    [SerializeField] private Animator portalAnimator;
    [SerializeField] private AudioSource portalActivationAudioSource;
    public bool IsActivated;

    public void Activate()
    {
        IsActivated = true;
        portalAnimator.SetBool("IsActive", true);
        portalActivationAudioSource.Play();
    }
}
