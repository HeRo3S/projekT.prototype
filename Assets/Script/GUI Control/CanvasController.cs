using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController: MonoBehaviour
{
    private static CanvasController _instance;
    public Canvas[] canvasList;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public static CanvasController GetInstance()
    {
        return _instance;
    }

    //Enable Canvas without turn all the others off
    public void EnableCanvas(Canvas target)
    {
        target.gameObject.SetActive(true);
    }
    //Enable Canvas and turn all the others off
    public void EnableOnlyCanvas(Canvas target)
    {
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
