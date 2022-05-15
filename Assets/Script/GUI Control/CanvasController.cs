using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController: MonoBehaviour
{
    private static CanvasController _instance;
    [SerializeField]
    private List<Canvas> canvasList;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        } else
        {
            Destroy(gameObject);
        }
        AttachAllCanvasIntoList();
    }

    public static CanvasController GetInstance()
    {
        return _instance;
    }

    private void AttachAllCanvasIntoList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Canvas canvasCheck = transform.GetChild(i).GetComponent<Canvas>();
            if (canvasCheck != null)
            {
                canvasList.Add(canvasCheck);
            }
        }
    }

    //Enable Canvas without turn all the others off
    public void EnableCanvas(string canvasName)
    {
        Canvas target = canvasList.Find(c => c.name == canvasName);
        target.gameObject.SetActive(true);
    }
    //Enable Canvas and turn all the others off
    public void EnableOnlyCanvas(string canvasName)
    {
        Canvas target = canvasList.Find(c => c.name == canvasName);
        foreach (Canvas c in canvasList)
        {
            DisableCanvas(c);
        }
        target.gameObject.SetActive(true);
    }
    public void DisableCanvas(Canvas target)
    {
        target.gameObject.SetActive(false);
    }
}
