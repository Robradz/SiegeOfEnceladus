using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadLevel", 2f);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
