using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 14;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    [SerializeField]
    private List<ItemBase> defaultInventory;
    [HideInInspector]
    public List<ItemBase> items = new List<ItemBase>();

    public void Awake()
    {
        //Load default inventory into inventory
        if(defaultInventory != null)
        {
            foreach(ItemBase item in defaultInventory)
            {
                items.Add(Instantiate(item));
            }
            defaultInventory = null;
        }
    }
    public void DestroyItemCheck(ItemBase item)
    {
        if (item.GetQuantity() <= 0)
        {
            items.Remove(item);
            Debug.Log(items);
        }
        return;
    }

    public void FirstTimeOpenInventoryCheck()
    {
        //Check quantity = 0 items
        for (int i = 0; i < items.Count; i++)
        {
            DestroyItemCheck(items[i]);
        }

    }

    //Add item function, if item's limit has been reached, function'll not create more items 
    public bool Add (ItemBase item)
    {
        if(items.Count >= space )
        {
            Debug.Log("Out of slot");
            return false;
        }

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetItemID() == item.GetItemID())
            {
                int addedQuantity = items[i].GetQuantity() + item.GetQuantity();
                if (addedQuantity > item.GetQuantityLimit())
                {
                    addedQuantity = item.GetQuantityLimit();
                }

                items[i].SetQuantity(addedQuantity);
                return true;
            }
        }

        if (!item.CanGetMore())
        {
            item.SetQuantity(item.GetQuantityLimit());
        }
        items.Add(item);

        if(onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
       
        return true;
    }

    public void Remove (ItemBase item)
    {
        items.Remove(item);

        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }

}
