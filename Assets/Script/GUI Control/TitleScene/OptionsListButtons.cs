using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsListButtons : MonoBehaviour
{
    private Button continueBtn; 
    private Button newgameBtn; 
    private Button settingsBtn; 
    private Button exitBtn;

    private void Awake()
    {
        AttachButtonsReferences();
        continueBtn.onClick.AddListener(ContinueButtonOnClick);
        newgameBtn.onClick.AddListener(NewGameButtonOnClick);
        settingsBtn.onClick.AddListener(SettingsButtonOnClick);
        exitBtn.onClick.AddListener(ExitButtonOnClick);
    }
    private void AttachButtonsReferences()
    {
        continueBtn = transform.Find("ContinueButton").GetComponent<Button>();
        newgameBtn= transform.Find("NewGameButton").GetComponent<Button>();
        settingsBtn = transform.Find("SettingsButton").GetComponent<Button>();
        exitBtn = transform.Find("ExitButton").GetComponent<Button>();
    }

    private void ContinueButtonOnClick()
    {
        gameObject.SetActive(false);
        transform.parent.Find("LoadSave").gameObject.SetActive(true);
    }

    private void NewGameButtonOnClick()
    {
        ScenesController.Instance.LoadScene("Ingame");
    }

    private void SettingsButtonOnClick()
    {

    }

    private void ExitButtonOnClick()
    {
        Application.Quit();
    }
}
