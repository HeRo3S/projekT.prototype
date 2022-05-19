using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

public class ScenesController : MonoBehaviour
{
    private static ScenesController _instance;
    public static ScenesController Instance
    {
        get
        {
            if (_instance == null )
            {
                var op = Addressables.LoadAssetAsync<GameObject>("PrefabSceneManager");
                _instance = Instantiate(op.WaitForCompletion()).GetComponent<ScenesController>();
                Addressables.Release(op);
            }
            return _instance;
        }
    }
    
    private void Awake()
    {
        //Singleton
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this);

    }


    public string CurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void LoadScene(string name)
    {
        StartCoroutine(AsyncLoadFunction(name));
    }

    private IEnumerator AsyncLoadFunction(string name)
    {
        var op = SceneManager.LoadSceneAsync(name);
        while (!op.isDone)
        {
            yield return null;
        }
        GameStateManager.Instance.SetCurrentSceneName(name);
    }

    public void ReloadScene()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
        GameStateManager.Instance.SetCurrentSceneName(thisScene.name);
    }
}
