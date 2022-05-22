using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AddressableAssets;

public class TextPopUp : MonoBehaviour
{
    private float timeToLive;
    public TextMeshPro textMesh { get; private set; }
    public static TextPopUp Create(string text, Vector3 position, float timeToLive)
    {
        TextPopUp target = Instantiate(AssetManager.Instance.pfTextPopUp, position, Quaternion.identity).GetComponent<TextPopUp>();
        target.SetUp(text, timeToLive);
        return target;
    }
    public void Awake()
    {
        textMesh = gameObject.GetComponent<TextMeshPro>();
    }
    private void SetUp(string text, float timeToLive)
    {
        textMesh.text = text;
        this.timeToLive = timeToLive;
    }

    private void FixedUpdate()
    {
        if(timeToLive <= 0)
        {
            Destroy(gameObject);
        }
        timeToLive-= Time.fixedDeltaTime;
    }
}
