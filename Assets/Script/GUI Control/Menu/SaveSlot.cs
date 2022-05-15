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
        switch (ScenesController.Instance.CurrentSceneName())
        {
            case "TitleScene":
                if (SaveSystem.DataExist(slotIndex))
                {
                    SaveSystem.LoadFromSlot(slotIndex);
                    ScenesController.Instance.LoadScene("Ingame");
                }
                break;
            case "Ingame":
                SaveSystem.SaveToSlot(slotIndex);
                RefreshDisplay();
                break;
            default:
                Debug.Log("Can't find Scene this Canvas is attached to.");
                break;
        }

    }

}