using System;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private OrbInventory inventory;
    [SerializeField] private PlayerRespawner respawner;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Camera camera;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Collider2D collider2D;    
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private AudioSource jumpAudioSource;
    public float distanceToGround;
    private const float MaxIdleSpeed = 0.2f;
    private const float Speed = 5.0F;
    private const float JumpHeight = 6.0F;

    public void Start()
    {
        distanceToGround = collider2D.bounds.extents.y;
    }
    
    public void Update()
    {
        var horizontalMove = Input.GetAxis("Horizontal");
        var velocity = new Vector3(horizontalMove, 0, 0);

        transform.position += velocity * (Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            respawner.Respawn();
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(bombPrefab, transform.position, quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidbody2D.AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse);
            jumpAudioSource.Play();
        }
        
        var speed = Math.Abs(horizontalMove);
        var direction = horizontalMove < 0 ? "left" : "right";

        if (speed <= MaxIdleSpeed)
        {
            spriteRenderer.sprite = idleSprite;
        } 
        else
            spriteRenderer.sprite = direction switch
            {
                "left" => leftSprite,
                "right" => rightSprite,
                _ => throw new Exception("Can't resolve a player sprite.")
            };
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Orb")) return;
        
        var orb = other.gameObject;
        inventory.GiveCommonOrb();
        Destroy(orb);
    }

    private bool IsGrounded()
    {
        var maxAllowedCliffJumpWidth = 0.5F;
        var raycastDirection = Vector2.down;
        var raycastBeamLength = 1.0F;
        var leftRayPosition = new Vector2(transform.position.x - maxAllowedCliffJumpWidth, transform.position.y);
        var rightRayPosition = new Vector2(transform.position.x + maxAllowedCliffJumpWidth, transform.position.y);
        
        return Physics2D.Raycast(leftRayPosition, raycastDirection, raycastBeamLength, LayerMask.GetMask("Ground")).collider is not null ||
               Physics2D.Raycast(rightRayPosition, raycastDirection, raycastBeamLength, LayerMask.GetMask("Ground")).collider is not null;
    }
}
