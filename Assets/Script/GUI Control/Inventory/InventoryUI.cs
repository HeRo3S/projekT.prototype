using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;

    public Transform itemsParent;
    private Button backbtn;
    private Button usebtn;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI desc;
    private TextMeshProUGUI hp;
    private TextMeshProUGUI mp;

    Inventory inventory;

    InventorySlot[] slots;
    InventorySlot currentSelectSlot;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        
        itemsParent = transform.Find("Inventory").Find("ItemParent");
        slots = itemsParent.GetComponentsInChildren<InventorySlot>(true);

        backbtn = transform.Find("BackButton").GetComponent<Button>();
        backbtn.onClick.AddListener(BackButtonOnClick);
        usebtn = transform.Find("UseButton").GetComponent<Button>();
        usebtn.onClick.AddListener(UseButtonOnClick);

        itemName = transform.Find("ItemDesc").Find("ItemName").GetComponent<TextMeshProUGUI>();
        desc = transform.Find("ItemDesc").Find("Desc").GetComponent<TextMeshProUGUI>();
        hp = transform.Find("Status").Find("HP").GetComponent<TextMeshProUGUI>();
        mp = transform.Find("Status").Find("MP").GetComponent<TextMeshProUGUI>();

        inventory = InstanceManager.Instance.currentInventory;
        inventory.onItemChangedCallBack += UpdateUI;


    }

    private void OnEnable()
    {
        inventory.onItemChangedCallBack.Invoke();
    }
    void UpdateUI()
    {
        hp.text = InstanceManager.Instance.player.GetHealth() + " / " + InstanceManager.Instance.player.GetMaxHP();
        mp.text = InstanceManager.Instance.player.GetMana() + " / " + InstanceManager.Instance.player.GetMaxMana();

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }

            if (currentSelectSlot != null && currentSelectSlot != slots[i])
            {
                slots[i].BlurSlot();
            } else
            {
                slots[i].UnblurSlot();
            }
        }

        if (currentSelectSlot != null )
        {
            itemName.text = currentSelectSlot.GetItem().GetItemName();
            desc.text = currentSelectSlot.GetItem().GetDescription();
        }

        Debug.Log("Updating UI");
    }

    private void BackButtonOnClick()
    {
        CanvasController.GetInstance().DisableCanvas(transform.GetComponent<Canvas>());
        CanvasController.GetInstance().EnableCanvas("IngameHUDCanvas");
        InstanceManager.Instance.gameStateManager.SwitchToStateIngame();
    }

    private void UseButtonOnClick()
    {
        if (currentSelectSlot == null)
        {
            Debug.Log("Please choose an item!");
            return;
        }
        currentSelectSlot.UseItem();
        inventory.DestroyItemCheck(currentSelectSlot.GetItem());
        UpdateUI();
    }

    public void SlotSelected(InventorySlot slot)
    {
        if (currentSelectSlot == slot)
        {
            SlotDeselected();
            return;
        }
        if(slot.GetItem() != null)
        {
            currentSelectSlot = slot;
        }
        UpdateUI();    
    }
    public void SlotDeselected()
    {
        currentSelectSlot = null;
        UpdateUI();
    }

}
