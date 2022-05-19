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
        InstanceManager.Instance.canvasController = _instance;
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
        GameStateManager.Instance.UpdateGameState();
    }
    //Enable Canvas and turn all the others off
    public void EnableOnlyCanvas(string canvasName)
    {
        Canvas target = canvasList.Find(c => c.name == canvasName);
        foreach (Canvas c in canvasList)
        {
            PrivateDisableCanvas(c);
        }
        target.gameObject.SetActive(true);
        GameStateManager.Instance.UpdateGameState();
    }
    //Disable canvas
    public void DisableCanvas(string canvasName)
    {
        Canvas target = canvasList.Find(c => c.name == canvasName);
        target.gameObject.SetActive(false);
    }

    private void PrivateDisableCanvas(Canvas target)
    {
        target.gameObject.SetActive(false);
    }
       //Check status of the canvas
    public bool IsCanvasActive(string canvasName)
    {
        Canvas target = canvasList.Find(c => c.name == canvasName);
        return target.gameObject.activeInHierarchy;
    }
}
