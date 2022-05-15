using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public string item_id;
    public int amount;
    public Item(string item_id, int amount)
    {
        this.item_id = item_id;
        this.amount = amount;
    }
}
