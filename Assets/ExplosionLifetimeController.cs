using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLifetimeController : MonoBehaviour
{
    [SerializeField] private AudioSource bombExplosionAudioSource;
    private const float Delay = 0.4F;
    
    void Start()
    {
        bombExplosionAudioSource.pitch = (float)(Random.value * 0.6 + 0.7);
        bombExplosionAudioSource.Play();
        StartCoroutine(DestroyWithDelay());
    }

    private IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(Delay);
        Destroy(gameObject);
    }
}
