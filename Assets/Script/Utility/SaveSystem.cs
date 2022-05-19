using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string saveDirectory = Application.persistentDataPath + "/Save/";
    public static int loadSlot = -1;
    public static void SaveToSlot(int slot)
    {
        ValidateDirectory();
        string saveFileLocation = saveDirectory + "save" + slot;
        Save saveData = new Save();
        foreach (ItemBase item in InstanceManager.Instance.currentInventory.items)
        {
            Item itemData = new Item(item.GetItemID(), item.GetQuantity());
            saveData.inventory.Add(itemData);
        }
        saveData.budget = InstanceManager.Instance.player.GetBudget();
        using StreamWriter writer = new StreamWriter(saveFileLocation, false);
        writer.Write(JsonUtility.ToJson(saveData, true));
    }
    private static void ValidateDirectory()
    {
        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }
    }

    public static bool DataExist(int slot)
    {
        string saveFileLocation = saveDirectory + "save" + slot;
        if (File.Exists(saveFileLocation))
        {
            return true;
        }
        return false;
    }
    public static void Load()
    {
        if(loadSlot != -1)
        {
            LoadFromSlot(loadSlot);
        }
        loadSlot = -1;
    }
    private static void LoadFromSlot(int slot)
    {
        if (DataExist(slot))
        {
            string saveFileLocation = saveDirectory + "save" + slot;

            StreamReader reader = new StreamReader(saveFileLocation);
            string dataString = reader.ReadToEnd();
            Save saveData = JsonUtility.FromJson<Save>(dataString);
            foreach (Item itemData in saveData.inventory)
            {
                ItemBase item = ScriptableObject.Instantiate(AssetLoader.LoadScriptable("Items/" + itemData.item_id)) as ItemBase;
                item.SetQuantity(itemData.amount);
                InstanceManager.Instance.currentInventory.Add(item);
            }
            InstanceManager.Instance.player.SetBudget(saveData.budget);
        }
    }
}
