using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetManager : MonoBehaviour
{
    private static AssetManager _instance;
    public static AssetManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var op = Addressables.LoadAssetAsync<GameObject>("PrefabAssetManager");
                _instance = Instantiate(op.WaitForCompletion()).GetComponent<AssetManager>();
                Addressables.Release(op);
            }
            return _instance;
        }
    }

    public GameObject pfTextPopUp;
    public GameObject pfArrow;
}
