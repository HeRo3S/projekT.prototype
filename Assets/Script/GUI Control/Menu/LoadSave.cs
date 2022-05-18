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
