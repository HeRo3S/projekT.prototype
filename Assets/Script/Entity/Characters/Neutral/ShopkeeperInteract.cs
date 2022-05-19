using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperInteract : MonoBehaviour, IIteractable
{
    [SerializeField]
    private Inventory inventory;
    private Dialogue dialogue;

    private void Awake()
    {
        inventory.FirstTimeOpenInventoryCheck();
        dialogue = transform.GetComponent<Dialogue>();
    }
    public void OnInteract()
    {
        Debug.Log("Shopkeeper");
        SetupShopCanvas();
    }

    public void SetupShopCanvas()
    {
        CanvasController.GetInstance().EnableOnlyCanvas("ShopCanvas");
        //GameStateManager.Instance.SwitchToStateIngameMenuOpened();
        ShopUI.instance.SetupInventory(inventory);
    }
}
