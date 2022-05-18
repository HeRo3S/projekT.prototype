using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController
{
    private static ScenesController _instance;
    public static ScenesController Instance
    {
        get
        {
            if (_instance == null ) _instance = new ScenesController();
            return _instance;
        }
    }

    public string CurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }

    public void ReloadScene()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }
}
