using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory! Fix pls");
            return;
        }
        instance = this;
    }

    public int space = 21;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public List<ItemBase> items = new List<ItemBase>();

    private void Start()
    {
        items.Add((ItemBase)AssetLoader.LoadScriptable("Items/Recovery/HealthPotion"));
        items.Add((ItemBase)AssetLoader.LoadScriptable("Items/Recovery/ManaPotion"));
        items.Add((ItemBase)AssetLoader.LoadScriptable("Items/Recovery/EnergyDrink"));
        items.Add((ItemBase)AssetLoader.LoadScriptable("Items/Equipment/Arrow"));
        items.Add((ItemBase)AssetLoader.LoadScriptable("Items/Equipment/Shortbow"));
        items.Add((ItemBase)AssetLoader.LoadScriptable("Items/Equipment/Square"));
        InstanceManager.Instance.currentInventory = gameObject.GetComponent<Inventory>();
    }
    public bool Add (ItemBase item)
    {
        if(items.Count >= space )
        {
            Debug.Log("Out of slot");
            return false;
        }

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == item.name)
            {
                items[i].SetQuantity(items[i].GetQuantity()+1);
                return true;
            }
        }

        if (item.CanGetMore() == true)
        {
            items.Add(item);
        }
        else
        {
            return false;
        }

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
