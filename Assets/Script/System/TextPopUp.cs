using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AddressableAssets;

public class TextPopUp : MonoBehaviour
{
    private int frameToLive;
    private TextMeshPro textMesh;
    public static TextPopUp Create(string text, Vector3 position, int frameToLive)
    {
        var op = Addressables.LoadAssetAsync<GameObject>("PFTextPopUp");
        GameObject popUpPrefab = op.WaitForCompletion();
        TextPopUp target = Instantiate(popUpPrefab, position, Quaternion.identity).GetComponent<TextPopUp>();
        Addressables.Release(op);
        target.SetUp(text, frameToLive);
        Debug.Log(target.transform.position);
        return target;
    }
    public void Awake()
    {
        textMesh = gameObject.GetComponent<TextMeshPro>();
    }
    private void SetUp(string text, int frameToLive)
    {
        textMesh.text = text;
        this.frameToLive = frameToLive;
    }

    private void FixedUpdate()
    {
        if(frameToLive <= 0)
        {
            Destroy(gameObject);
        }
        frameToLive--;
    }
}
