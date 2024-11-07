using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{
    [SerializeField] private AudioSource respawnAudioSource;
    private Vector2 spawnPoint;
    
    void Start()
    {
        spawnPoint = transform.position;
    }

    public void Respawn()
    {
        transform.position = spawnPoint;
        respawnAudioSource.Play();
    }
}
