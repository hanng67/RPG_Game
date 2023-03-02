using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBagWindow : MonoBehaviour
{
    public InventoryObject Inventory;
    public GameObject Container;
    public GameObject InventorySlotPrefab;
    public List<UIInventorySlot> InventorySlots = new List<UIInventorySlot>();
    public BaseItem ActiveItem;
    public Text UseBtnText;

    private void Awake()
    {
        for (int i = 0; i < Inventory.MaxNumberInventory; i++)
        {
            GameObject inventorySlot = Instantiate(InventorySlotPrefab, Container.transform);
            inventorySlot.GetComponent<UIInventorySlot>().ResetInfo();
            InventorySlots.Add(inventorySlot.GetComponent<UIInventorySlot>());
        }
    }

    private void OnEnable()
    {
        UpdateInfo();
        Events.EventSelectItem.AddListener(SelectItem);
    }
    private void OnDisable()
    {
        Events.EventSelectItem.RemoveListener(SelectItem);
    }

    public void UpdateInfo(bool isNeedResetInfo = false)
    {
        int idx = 0;
        foreach (KeyValuePair<string, ItemSlot> inventorySlot in Inventory.Container)
        {
            ItemSlot itemInfo = inventorySlot.Value;
            if (itemInfo == null) break;
            InventorySlots[idx++].UpdateInfo(itemInfo);
        }
    }

    public void SelectItem(ItemSlot itemSelected)
    {
        ActiveItem = itemSelected.Item;
        UseBtnText.text = "Use";
        if(ActiveItem.Type == ItemTypes.Equipment) UseBtnText.text = "Equip";
    }

    public void UseItem(int selectChar)
    {

    }

    public void DiscardItem()
    {

    }
}
