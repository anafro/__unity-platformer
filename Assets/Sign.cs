using TMPro;
using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField] private AudioSource readAudioSource;
    [SerializeField] private CircleCollider2D collider2D;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string content;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Sign::OnCollisionEnter2D(Collision2D other)");
        
        if (!other.gameObject.CompareTag("Player")) return;
        
        text.text = content;
        readAudioSource.Play();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Sign::OnCollisionExit2D(Collision2D other)");
        
        if (!other.gameObject.CompareTag("Player")) return;

        text.text = "";
    }
}
