using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// ReSharper disable MemberCanBeMadeStatic.Local
// ReSharper disable ArrangeTypeMemberModifiers

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Invoke(nameof(LoadFirstScene), 2f);
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
