using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : ScriptableObject, IUsable
{
    //Item infomation
    [SerializeField]
    protected string itemID;
    [SerializeField]
    protected string itemName;
    [SerializeField]
    protected string itemDescription;
    //Item stat
    [SerializeField]
    protected int price;
    [SerializeField]
    protected int quantityCarrying;
    [SerializeField]
    protected int quantityLimit;
    //Display
    [SerializeField]
    protected Sprite icon;

    public bool CanUse()
    {
        return (quantityCarrying > 0);
    }

    public bool CanGetMore()
    {
        return (quantityCarrying < quantityLimit);
    }

    public string GetItemName()
    {
        return itemName;
    }
    public string GetDescription()
    {
        return itemDescription;
    }
    public Sprite GetIcon()
    {
        return icon;
    }

    public void SetQuantity(int quantityCarrying)
    {
        this.quantityCarrying = quantityCarrying;
    }

    public int GetQuantity()
    {
        return quantityCarrying;
    }

    //Use Item function
    public virtual void OnActive()
    {
        quantityCarrying -= 1;
    }
    public string GetItemID()
    {
        return itemID;
    }
}
