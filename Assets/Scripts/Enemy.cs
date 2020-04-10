using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject deathFX;    
    [SerializeField] private Transform parent;
    [SerializeField] private int scorePerHit = 12;


    private Scoreboard _scoreboard;
    private void Start()
    {
        AddNonTriggerBoxCollider();
        _scoreboard = FindObjectOfType<Scoreboard>();
    }

    void AddNonTriggerBoxCollider()
    {
        Collider nonTriggerBoxCollider = gameObject.AddComponent<BoxCollider>();
        nonTriggerBoxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        _scoreboard.ScoreHit(scorePerHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
