using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour, IIteractable
{
    [SerializeField]
    protected List<GameObject> runeObjects;
    [SerializeField]
    protected float switchColorTime;
    protected List<SpriteRenderer> runeRenderers = new List<SpriteRenderer>();
    [SerializeField]
    protected Color runeColor;
    protected Color targetColor;
    protected Color currentColor;
    public void Start()
    {
        foreach (GameObject runeObj in runeObjects)
        {
            runeRenderers.Add(runeObj.GetComponent<SpriteRenderer>());
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            StopAllCoroutines();
            targetColor = runeColor;
            StartCoroutine(SwitchColorCR());
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            StopAllCoroutines();
            targetColor = Color.clear;
            StartCoroutine(SwitchColorCR());
        }
    }

    protected IEnumerator SwitchColorCR()
    {
        Color starColor = currentColor;
        for (float i = 0f; i < switchColorTime; i += Time.deltaTime)
        {
            i = (i > switchColorTime) ? switchColorTime : i ;
            currentColor = starColor + (targetColor - starColor) * i / switchColorTime;
            foreach(SpriteRenderer rune in runeRenderers)
            {
                rune.color = currentColor;
            }

            yield return null;
        }
    }

    public void OnInteract()
    {
        CanvasController.GetInstance().EnableOnlyCanvas("LoadSave");
        //GameStateManager.Instance.SwitchToStateIngameMenuOpened();
    }
}
