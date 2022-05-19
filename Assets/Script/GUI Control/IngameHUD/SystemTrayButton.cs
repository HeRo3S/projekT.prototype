using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemTrayButton : MonoBehaviour
{
    private Button button;
    [SerializeField]
    private Canvas linkedCanvas;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OpenCanvas);
    }

    private void OpenCanvas()
    {
        if (linkedCanvas == null)
        {
            Debug.Log("There isn't any canvas linked to this button. Check this button prefab.");
            return;
        }
        CanvasController.GetInstance().EnableOnlyCanvas(linkedCanvas.name);
        //GameStateManager.Instance.SwitchToStateIngameMenuOpened();
    }

}
