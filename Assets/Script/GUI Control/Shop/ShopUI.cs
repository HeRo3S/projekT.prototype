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
    private Button buybtn;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI desc;
    private TextMeshProUGUI playerBudget;

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
        buybtn = transform.Find("Cart").Find("BuyButton").GetComponent<Button>();
        buybtn.onClick.AddListener(BuyButtonOnClick);
        itemName = transform.Find("ItemDesc").Find("ItemName").GetComponent<TextMeshProUGUI>();
        desc = transform.Find("ItemDesc").Find("Desc").GetComponent<TextMeshProUGUI>();
        playerBudget = transform.Find("ItemDesc").Find("PlayerBudget").GetComponent<TextMeshProUGUI>();

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

        playerBudget.text = InstanceManager.Instance.player.GetBudget().ToString();

        if (currentSelectSlot != null )
        {
            itemName.text = currentSelectSlot.GetItem().GetItemName();
            desc.text = currentSelectSlot.GetItem().GetDescription();
        }
    }

    private void BackButtonOnClick()
    {
        CanvasController.GetInstance().EnableOnlyCanvas("IngameHUDCanvas");
        //GameStateManager.Instance.SwitchToStateIngame();
        Receipts.instance.ClearListAfterBuy();
    }

    private void AddButtonOnClick()
    {
        if (currentSelectSlot == null)
        {
            Debug.Log("Please choose an item!");
            return;
        }
        ItemBase selectedItem = currentSelectSlot.GetItem();
        ItemBase addItem = Instantiate(selectedItem);
        //selectedItem.SetQuantity(selectedItem.GetQuantity() - 1);
        addItem.SetQuantity(1);
        Receipts.instance.AddItemIntoWishList(addItem);
        /**
        currentSelectSlot.UseItem();
        inventory.DestroyItemCheck(currentSelectSlot.GetItem());
        UpdateUI();
        */
        //Need to refactor this
    }

    private void BuyButtonOnClick()
    {
        Receipts.instance.Transaction();
        UpdateUI();
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
