using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiedDialogue : MonoBehaviour
{
    Button backBtn;
    Button resurrectBtn;
    Button ragequitBtn;

    private void Awake()
    {
        backBtn = transform.GetChild(0).Find("BackButton").GetComponent<Button>();
        backBtn.onClick.AddListener(BackButtonOnClick);
        resurrectBtn = transform.GetChild(0).Find("ResurrectButton").GetComponent<Button>();
        resurrectBtn.onClick.AddListener(RessurrectButtonOnClick);
        ragequitBtn = transform.GetChild(0).Find("RagequitButton").GetComponent<Button>();
        ragequitBtn.onClick.AddListener(RagequitButtonOnClick);
    }

    private void BackButtonOnClick()
    {
        CanvasController.GetInstance().EnableOnlyCanvas("IngameHUDCanvas");
        GameStateManager.Instance.SwitchToStateIngame();
    }


    private void RessurrectButtonOnClick()
    {
        ScenesController.Instance.ReloadScene();
    }

    private void RagequitButtonOnClick()
    {
        Application.Quit();
    }

}
