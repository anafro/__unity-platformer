using System.Collections;
using UnityEngine;

public class BombExplosionController : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private AudioSource bombSpawnAudioSource;
    private const float MaxExplosionForce = 24.0F;
    private const float ExplosionRadius = 12.0F;
    
    void Start()
    {
        bombSpawnAudioSource.Play();
        StartCoroutine(ExplodeWithDelay());
    }

    private IEnumerator ExplodeWithDelay()
    {
        yield return new WaitForSeconds(3.0F);
        
        var bombPosition = (Vector2) transform.position;

        foreach (var rigidbody in FindObjectsOfType<Rigidbody2D>())
        {
            var rigidbodyPosition = (Vector2) rigidbody.gameObject.transform.position;
            var impulseVector = rigidbodyPosition - bombPosition;
            var distanceToBomb = impulseVector.magnitude;
            var explosionDirection = impulseVector.normalized;
            var explosionForce = MaxExplosionForce - MaxExplosionForce * Mathf.Clamp(distanceToBomb, 0, ExplosionRadius) / ExplosionRadius;
            var explosionImpulse = explosionDirection * explosionForce;
            
            rigidbody.AddForce(explosionImpulse, ForceMode2D.Impulse);
            Debug.Log(explosionImpulse);
            Debug.Log(rigidbody.gameObject.tag);
        }

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
