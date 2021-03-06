using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    public int slotIndex;
    [SerializeField]
    private TextMeshProUGUI display;
    private Button button;
    public void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }
    public void RefreshDisplay()
    {
        if (SaveSystem.DataExist(slotIndex))
        {
            display.text = "SAVE " + slotIndex;
        }
        else
        {
            display.text = "EMPTY";
        }
    }
    public void OnButtonClick()
    {
        //Game state code: 0 - inTitleMenu, 1 - inGame, 2 - ingameMenuOpened
        switch(GameStateManager.Instance.GetGameState())
        {
            case Enumeration.GameState.IN_MAINMENU:
            case Enumeration.GameState.INGAME_PLAYER_DIED:
                if (SaveSystem.DataExist(slotIndex))
                {
                    SaveSystem.loadSlot = slotIndex;
                    ScenesController.Instance.LoadScene("Ingame");
                }
                break;
            case Enumeration.GameState.INGAME_UI_OPEN:
                SaveSystem.SaveToSlot(slotIndex);
                RefreshDisplay();
                break;
            default:
                Debug.Log("Something's wrong with game state.");
                break;
        }
        
    }

}