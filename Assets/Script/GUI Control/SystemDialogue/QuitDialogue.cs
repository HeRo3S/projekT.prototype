using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitDialogue : MonoBehaviour
{
    Button backBtn;
    Button ragequitBtn;
    Button mainmenuBtn;
    private void Awake()
    {
        backBtn = transform.Find("Panel").Find("BackButton").GetComponent<Button>();
        backBtn.onClick.AddListener(BackButtonOnClick);
        ragequitBtn = transform.Find("Panel").Find("RagequitButton").GetComponent<Button>();
        ragequitBtn.onClick.AddListener(RagequitButtonOnClick);
        mainmenuBtn= transform.Find("Panel").Find("MenuButton").GetComponent<Button>();
        mainmenuBtn.onClick.AddListener(BackToMainMenuButtonOnClick);
    }

    private void BackButtonOnClick()
    {
        CanvasController.GetInstance().EnableOnlyCanvas("IngameHUDCanvas");
        //GameStateManager.Instance.SwitchToStateIngame();
    }

    private void BackToMainMenuButtonOnClick()
    {
        ScenesController.Instance.LoadScene("TitleScene");
    }
    private void RagequitButtonOnClick()
    {
        Application.Quit();
    }

}
