using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public string loadLevel;

    public void loadScene()
    {

        SceneManager.LoadScene(loadLevel);


    }
}