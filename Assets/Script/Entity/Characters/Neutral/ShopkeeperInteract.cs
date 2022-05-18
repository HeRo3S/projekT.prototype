using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperInteract : MonoBehaviour, IIteractable
{
    Inventory inventory;

    private void Awake()
    {
        inventory = transform.parent.GetComponent<Shopkeeper>().GetInventory();
        inventory.FirstTimeOpenInventoryCheck();
    }
    public void OnInteract()
    {
        Debug.Log("Shopkeeper");
        SetupShopCanvas();
    }

    public void SetupShopCanvas()
    {
        CanvasController.GetInstance().EnableOnlyCanvas("ShopCanvas");
        ShopUI.instance.SetupInventory(inventory);
    }
}
