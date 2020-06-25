using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadLevel", 2f);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
