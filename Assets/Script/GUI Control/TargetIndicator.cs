using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class TargetIndicator : MonoBehaviour
{
    private static TargetIndicator _instance;
    public static TargetIndicator Instance
    {
        get
        {
            if (_instance == null)
            {
                var op = Addressables.LoadAssetAsync<GameObject>("PrefabTargetIndicator");
                _instance = Instantiate(op.WaitForCompletion()).GetComponent<TargetIndicator>();
                Addressables.Release(op);
            }
            return _instance;
        }
    }
}
