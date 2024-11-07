using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerZoomController : MonoBehaviour
{
    [SerializeField] private Tilemap grassTilemap;
    [SerializeField] private Camera camera;
    private const int TilemapObservationDiameter = 8;
    private const float MaxCameraSize = 12.5F;
    private const float MinCameraSize = 2.5F;
    private const float SmoothTime = 0.25F;
    private float velocity;
    private float size;
    private float levelPreviewDurationSeconds = 1.0F;

    private void Start()
    {
        size = camera.orthographicSize;
    }

    void Update()
    {
        if (levelPreviewDurationSeconds >= 0)
        {
            levelPreviewDurationSeconds -= Time.deltaTime;
            return;
        }

        var grassTilesCountAround = 0;
        
        for (var x = (int) transform.position.x - TilemapObservationDiameter / 2;
             x <= (int) transform.position.x + TilemapObservationDiameter / 2;
             x++)
        {
            for (var y = (int) transform.position.y - TilemapObservationDiameter / 2;
                 y <= (int) transform.position.y + TilemapObservationDiameter / 2;
                 y++)
            {
                if (grassTilemap.HasTile(new Vector3Int(x, y, 0)))
                {
                    grassTilesCountAround += 1;
                }
            }
        }

        // The "1 -" is added to invert the camera behavior
        // so it will zoom out if there are less grass tiles around. 
        var cameraSizePercent = 1 - grassTilesCountAround / Math.Pow(TilemapObservationDiameter, 2);

        size = (float)(cameraSizePercent * (MaxCameraSize - MinCameraSize) + MinCameraSize);
        camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, size, ref velocity, SmoothTime);
    }
}
