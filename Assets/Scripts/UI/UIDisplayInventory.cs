using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplayInventory : MonoBehaviour
{
    public InventoryObject Inventory;
    public GameObject Container;
    public GameObject InventorySlotPrefab;
    public List<UIInventorySlot> InventorySlots = new List<UIInventorySlot>();

    private void Awake() {
        for (int i = 0; i < Inventory.MaxNumberInventory; i++)
        {
            GameObject inventorySlot = Instantiate(InventorySlotPrefab, Container.transform) as GameObject;
            inventorySlot.GetComponent<UIInventorySlot>().UpdateInfo();
            InventorySlots.Add(inventorySlot.GetComponent<UIInventorySlot>());
        }
    }

    private void OnEnable() {
        UpdateInfo();
    }

    public void UpdateInfo(bool isNeedResetInfo = false){
        if(isNeedResetInfo) ResetInventoryInfo();

        int idx = 0;
        foreach (KeyValuePair<string, ItemInfo> inventorySlot in Inventory.Container)
        {
            ItemInfo itemInfo = inventorySlot.Value;
            InventorySlots[idx++].UpdateInfo(itemInfo.Stats.Sprite, $"{itemInfo.Amount}");
        }
    }

    public void ResetInventoryInfo(){
        for (int i = 0; i < InventorySlots.Count; i++)
        {
            InventorySlots[i].UpdateInfo();
        }
    }
}
