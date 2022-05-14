using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    ItemBase item;

    public Image icon;

    public Button removeButton;

    private void Start()
    {
        icon = transform.GetChild(0).GetComponentInChildren<Image>();
        removeButton = transform.Find("RemoveButton").GetComponent<Button>();
    }

    public void AddItem(ItemBase newItem)
    {
        item = newItem;
        icon.sprite= item.getIcon();
        icon.preserveAspect = true;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot ()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);    
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
