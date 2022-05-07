using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class InstanceManager : MonoBehaviour
{
    private static InstanceManager _instance;
    public static InstanceManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var op = Addressables.LoadAssetAsync<GameObject>("PrefabInstanceManager");
                _instance = Instantiate(op.WaitForCompletion()).GetComponent<InstanceManager>();
                Addressables.Release(op);
            }
            return _instance;
        }
    }
    public void Awake()
    {
        mainCamera = Camera.main;
    }

    public void Reload()
    {
        _instance = null;
    }
    public Camera mainCamera;
    public Player player;
    public ContactFilter2D groundEntityFilter;
}
