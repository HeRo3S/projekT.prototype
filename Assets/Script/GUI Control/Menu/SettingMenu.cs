using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private Button backBtn;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        backBtn = transform.Find("Panel").Find("BackButton").GetComponent<Button>();
        backBtn.onClick.AddListener(BackButtonOnClick);

    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex, true);
    }
    private void BackButtonOnClick()
    {
        gameObject.SetActive(false);
        GameStateManager gameState = GameStateManager.Instance;
        //Game state code: 0 - inTitleMenu, 1 - inGame, 2 - ingameMenuOpened
        switch(gameState.GetGameState())
        {
            case Enumeration.GameState.IN_MAINMENU:
                CanvasController.GetInstance().EnableOnlyCanvas("OptionsList");
                gameState.SwitchToStateTitleScreen();
                break;
            case Enumeration.GameState.INGAME_UI_OPEN:
                CanvasController.GetInstance().EnableOnlyCanvas("IngameHUDCanvas");
                gameState.SwitchToStateIngame();
                break;
            default:
                Debug.Log("Something's wrong with game state.");
                break;
        }
    }

}
