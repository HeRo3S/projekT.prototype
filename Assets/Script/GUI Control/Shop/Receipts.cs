using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using TMPro;

public class Receipts : MonoBehaviour
{
    public static Receipts instance;
    [SerializeField]
    private List<ItemBase> WishListItems = new List<ItemBase>();
    private List<GameObject> CartsTextHolder = new List<GameObject>();
    private int totalPrice;
    AsyncOperationHandle<GameObject> opHandle;
    GameObject cartTextHolderPrefab;

    private TextMeshProUGUI totalPriceTextHolder;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        totalPriceTextHolder = transform.parent.Find("TotalPrice").GetComponent<TextMeshProUGUI>();
    }

    public void Start()
    {
        cartTextHolderPrefab = AssetManager.Instance.pfCartTextHolder;
    }

    public void AddItemIntoWishList(ItemBase item)
    {
        PushIntoWishList(item);
        if (WishListItems.Count > CartsTextHolder.Count)
        {
            SetupTextHolderInfomation(item);
        } else
        {
            UpdateGameObjectList();
        }
        CalculateTotalPrice();
    }

    private void PushIntoWishList(ItemBase item)
    {
        //push into wish list WishListItems
       
        for (int i = 0; i < WishListItems.Count; i++)
        {
            if (WishListItems[i].GetItemID() == item.GetItemID())
            {
                int addedQuantity = WishListItems[i].GetQuantity() + 1;
                WishListItems[i].SetQuantity(addedQuantity);
                return;
            }
        }

        if (!item.CanGetMore())
        {
            item.SetQuantity(item.GetQuantityLimit());
        }
        item.SetQuantity(1);
        WishListItems.Add(item);
    }

    //update game object list
    private void UpdateGameObjectList()
    {
        TextMeshProUGUI tempItemName, tempItemPrice, tempItemQuantity;
        for (int i = 0; i < WishListItems.Count; i++)
        {
            tempItemName = CartsTextHolder[i].transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            tempItemPrice = CartsTextHolder[i].transform.Find("Price").GetComponent<TextMeshProUGUI>();
            tempItemQuantity = CartsTextHolder[i].transform.Find("Quantity").GetComponent<TextMeshProUGUI>();
            tempItemName.text = WishListItems[i].GetItemName();
            tempItemPrice.text = (WishListItems[i].GetPrice() * WishListItems[i].GetQuantity()).ToString();
            tempItemQuantity.text = WishListItems[i].GetQuantity().ToString();
        }
    }

    private void SetupTextHolderInfomation(ItemBase item)
    {
        GameObject go = Instantiate(cartTextHolderPrefab, transform);
        TextMeshProUGUI itemName = go.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI itemPrice= go.transform.Find("Price").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI itemQuantity = go.transform.Find("Quantity").GetComponent<TextMeshProUGUI>();
        itemName.text = item.GetItemName();
        itemPrice.text = (item.GetPrice()*item.GetQuantity()).ToString();
        itemQuantity.text = item.GetQuantity().ToString();

        CartsTextHolder.Add(go);
    }
    
    public void CalculateTotalPrice()
    {
        totalPrice = 0;
        for (int i = 0; i < WishListItems.Count; i++)
        {
            totalPrice += WishListItems[i].GetPrice() * WishListItems[i].GetQuantity();
        }
        totalPriceTextHolder.text = totalPrice.ToString();
    }

}
