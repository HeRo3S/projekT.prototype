using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    private Button backbtn;
    
    Inventory inventory;

    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        backbtn = transform.Find("BackButton").GetComponent<Button>();
        backbtn.onClick.AddListener(BackButtonOnClick);

        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>(true);
        UpdateUI();
    }   
     
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if ( i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

        Debug.Log("Updating UI");
    }

    private void BackButtonOnClick()
    {
        CanvasController.GetInstance().DisableCanvas(transform.GetComponent<Canvas>());
        CanvasController.GetInstance().EnableCanvas(this.transform.parent.Find("IngameHUDCanvas").GetComponent<Canvas>());
        Time.timeScale = 1f;
    }

}
