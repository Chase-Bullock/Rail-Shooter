using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// ReSharper disable MemberCanBeMadeStatic.Local
// ReSharper disable ArrangeTypeMemberModifiers

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(LoadFirstScene), 3f);
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1); 
    }

}
