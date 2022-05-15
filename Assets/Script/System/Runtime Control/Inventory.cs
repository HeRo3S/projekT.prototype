using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
        instance = this;
        InstanceManager.Instance.currentInventory = this;
    }

    public int space = 21;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public List<ItemBase> items = new List<ItemBase>();

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
