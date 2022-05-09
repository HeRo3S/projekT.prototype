using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : ScriptableObject
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
        return quantityCarrying > 0;
    }

    public bool CanGetMore()
    {
        return (quantityCarrying < quantityLimit);
    }

    public Sprite getIcon()
    {
        return icon;
    }

    public virtual void OnActive()
    {
        quantityCarrying -= 1;
    }
}
