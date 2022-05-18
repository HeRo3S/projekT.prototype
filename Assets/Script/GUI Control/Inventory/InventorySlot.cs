using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventorySlot : MonoBehaviour
{
    ItemBase item;

    public Image icon;

    [SerializeField]
    private Button removeButton;
    [SerializeField]
    private Button itemButton;
    [SerializeField]
    private TextMeshProUGUI quantity;

    private void Awake()
    {
        itemButton.onClick.AddListener(ItemButtonOnclick);
        removeButton.onClick.AddListener(OnRemoveButton);
    }

    public void AddItem(ItemBase newItem)
    {
        if (newItem == null) return;
        item = newItem;
        icon.sprite= item.GetIcon();
        icon.preserveAspect = true;
        icon.enabled = true;
        quantity.text = item.GetQuantity().ToString();
        quantity.enabled = true;
        removeButton.interactable = false;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        quantity.enabled = false;
        removeButton.interactable = false;
    }

    public void BlurSlot()
    {
        icon.color = Color.gray;
    }

    public void UnblurSlot()
    {
        icon.color = new Color(255, 255, 255, 100);
    }

    public void ItemButtonOnclick()
    {
        InventoryUI.instance.SlotSelected(this);
    }

    public void OnRemoveButton()
    {
        InstanceManager.Instance.currentInventory.Remove(item);    
    }

    public void UseItem()
    {
        item.OnActive();
    }

    public ItemBase GetItem()
    {
        return item;
    }
}
