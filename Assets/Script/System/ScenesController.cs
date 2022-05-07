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

    public void ReloadScene()
    {
        InstanceManager.Instance.Reload();
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }
}