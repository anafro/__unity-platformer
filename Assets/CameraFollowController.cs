using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollowController : MonoBehaviour
{
    private Vector3 offset = new(0F, 0F, -10F);
    private Vector3 velocity = Vector3.zero;
    private const float SmoothSpeed = 0.2F;
    
    [SerializeField] private Transform playerTransform;

    void LateUpdate()
    {
        var cameraPosition = playerTransform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, cameraPosition, ref velocity, SmoothSpeed);
    }
}
