using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("In Seconds")][SerializeField] private float levelLoadDelay = 2f;
    [SerializeField] private GameObject deathFX;


    private void OnTriggerEnter(Collider other)
    {
        deathFX.SetActive(true);
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        Invoke(nameof(LoadFirstLevel), levelLoadDelay);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}
