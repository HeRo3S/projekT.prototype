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
        TextPopUp target = Instantiate(AssetManager.Instance.pfTextPopUp, position, Quaternion.identity).GetComponent<TextPopUp>();
        target.SetUp(text, frameToLive);
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
