using TMPro;
using UnityEngine;

public class OrbInventory : MonoBehaviour
{
    [SerializeField] private PortalActivator portalActivator;
    [SerializeField] private TextMeshProUGUI orbsCollectedText;
    [SerializeField] private AudioSource commonOrbPickupAudioSource;
    private int CommonOrbsCount;
    private int MaxCommonOrbsCountPerLevel;
    public bool AreAllCommonOrbsCollected => CommonOrbsCount >= MaxCommonOrbsCountPerLevel;

    private void Start()
    {
        MaxCommonOrbsCountPerLevel = GameObject.FindGameObjectsWithTag("Orb").Length;
        UpdateOrbText();
    }

    public void GiveCommonOrb()
    {
        CommonOrbsCount += 1;
        UpdateOrbText();
        commonOrbPickupAudioSource.Play();

        if (AreAllCommonOrbsCollected)
        {
            portalActivator.Activate();
        }
    }

    private void UpdateOrbText()
    {
        orbsCollectedText.text = $"{CommonOrbsCount} orbs collected out of {MaxCommonOrbsCountPerLevel}";
    }
}
