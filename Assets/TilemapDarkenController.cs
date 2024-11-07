using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[Obsolete] public class TilemapDarkenController : MonoBehaviour
{
    [SerializeField] private TilemapRenderer tilemapRenderer;
    private const float Darkness = 0.35F;
    
    void Start()
    {
        // tilemapRenderer.material.color = new Color(Darkness, Darkness, Darkness, 1.0F);
    }
}
