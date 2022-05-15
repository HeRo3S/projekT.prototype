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
        backBtn = transform.Find("BackButton").GetComponent<Button>();
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
        switch(ScenesController.Instance.CurrentSceneName())
        {
            case "TitleScene":
                //transform.parent.Find("OptionsList").gameObject.SetActive(true);
                CanvasController.GetInstance().EnableOnlyCanvas("OptionsList");
                break;
            case "Ingame":
                //transform.parent.Find("IngameHUDCanvas").gameObject.SetActive(true);
                CanvasController.GetInstance().EnableOnlyCanvas("IngameHUDCanvas");
                Time.timeScale = 1f;
                break;
            default:
                Debug.Log("Can't find Scene this Canvas is attached to.");
                break;
        }
    }
}
