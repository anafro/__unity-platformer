using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHeightColorController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private const float MaxHeight = -5F;
    private const float MinHeight = -60F;
    private static readonly Color SkyColor = new(36f / 255, 159f / 255, 222f / 255);
    private static readonly Color DepthColor = new(0, 0, 0);
    
    void Update()
    {
        var height = transform.position.y;
        var lerpPosition = 1 - Mathf.Clamp01((height - MinHeight) / (MaxHeight - MinHeight));
        camera.backgroundColor = Color.Lerp(SkyColor, DepthColor, lerpPosition);
    }
}
