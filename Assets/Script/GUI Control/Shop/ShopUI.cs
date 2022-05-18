using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI: MonoBehaviour
{
    public static ShopUI instance;

    private Transform itemsParent;
    private Button backbtn;
    private Button addbtn;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI desc;

    Receipts receipts;
    Inventory inventory;

    ShopSlot[] slots;
    ShopSlot currentSelectSlot;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        itemsParent = transform.Find("Shop").Find("ItemParent");
        slots = itemsParent.GetComponentsInChildren<ShopSlot>(true);

        backbtn = transform.Find("BackButton").GetComponent<Button>();
        backbtn.onClick.AddListener(BackButtonOnClick);
        addbtn = transform.Find("ItemDesc").Find("AddButton").GetComponent<Button>();
        addbtn.onClick.AddListener(AddButtonOnClick);
        itemName = transform.Find("ItemDesc").Find("ItemName").GetComponent<TextMeshProUGUI>();
        desc = transform.Find("ItemDesc").Find("Desc").GetComponent<TextMeshProUGUI>();

    }

    public void SetupInventory(Inventory inv)
    {
        inventory = inv;
        inventory.onItemChangedCallBack += UpdateUI;
        inventory.onItemChangedCallBack.Invoke();
    }

    void UpdateUI()
    {
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
    }

    private void BackButtonOnClick()
    {
        CanvasController.GetInstance().DisableCanvas(transform.GetComponent<Canvas>());
        CanvasController.GetInstance().EnableCanvas("IngameHUDCanvas");
        InstanceManager.Instance.gameStateManager.SwitchToStateIngame();
    }

    private void AddButtonOnClick()
    {
        if (currentSelectSlot == null)
        {
            Debug.Log("Please choose an item!");
            return;
        }
        ItemBase addItem = Instantiate(currentSelectSlot.GetItem());
        addItem.SetQuantity(1);
        Receipts.instance.AddItemIntoWishList(addItem);
        /**
        currentSelectSlot.UseItem();
        inventory.DestroyItemCheck(currentSelectSlot.GetItem());
        UpdateUI();
        */
        //Need to refactor this
    }

    public void SlotSelected(ShopSlot slot)
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

    public Inventory GetInventory()
    {
        return inventory;
    }


}
