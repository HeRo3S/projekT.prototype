using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class AssetLoader
{
    public static ScriptableObject LoadScriptable(string path)
    {
        var op = Addressables.LoadAssetAsync<ScriptableObject>(path);
        ScriptableObject result = op.WaitForCompletion();
        //Addressables.Release(op);
        return result;
    }
    public static GameObject LoadPrefab(string path)
    {
        var op = Addressables.LoadAssetAsync<GameObject>(path);
        GameObject result = op.WaitForCompletion();
        //Addressables.Release(op);
        return result;
    }
}
