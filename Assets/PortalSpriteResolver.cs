using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete] public class PortalSpriteResolver : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite activePortalSprite;
    [SerializeField] private Sprite inactivePortalSprite;
    
    void Update()
    {
        // spriteRenderer.sprite = Random.Range(0, 1) > 0.5 ? activePortalSprite : inactivePortalSprite;
        // spriteRenderer.sprite = activePortalSprite;
    }
}
