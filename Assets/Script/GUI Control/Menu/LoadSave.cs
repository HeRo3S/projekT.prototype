using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSave : MonoBehaviour
{
    private Button backBtn;
    [SerializeField]
    private SaveSlot[] saveSlots;
    private void Awake()
    {
        backBtn = transform.GetChild(0).Find("BackButton").GetComponent<Button>();
        backBtn.onClick.AddListener(BackButtonOnClick);
        saveSlots = GetComponentsInChildren<SaveSlot>(true);
        for(int i = 0; i < saveSlots.Length; i++)
        {
            saveSlots[i].slotIndex = i + 1;
        }
    }
    public void OnEnable()
    {
        foreach(SaveSlot slot in saveSlots)
        {
            slot.RefreshDisplay();
        }
    }

    private void BackButtonOnClick()
    {
        gameObject.SetActive(false);
        //Game state code: 0 - inTitleMenu, 1 - inGame, 2 - ingameMenuOpened
        switch(InstanceManager.Instance.gameStateManager.GetGameState())
        {
            case 0:
                CanvasController.GetInstance().EnableOnlyCanvas("OptionsList");
                InstanceManager.Instance.gameStateManager.SwitchToStateTitleScreen();
                break;
            case 2:
                CanvasController.GetInstance().EnableOnlyCanvas("IngameHUDCanvas");
                InstanceManager.Instance.gameStateManager.SwitchToStateIngame();
                break;
            default:
                Debug.Log("Something's wrong with game state.");
                break;
        }
    }
}
