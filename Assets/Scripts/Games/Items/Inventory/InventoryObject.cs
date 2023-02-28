using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Inventory Object", menuName = "Scriptable Object/Inventory")]
public class InventoryObject : ScriptableObject
{
    public Dictionary<string, ItemSlot> Container = new Dictionary<string, ItemSlot>();
    public int MaxNumberInventory;

    public void AddItem(ItemSlot itemSlot)
    {
        if (Container.ContainsKey(itemSlot.Item.Name))
        {
            Container[itemSlot.Item.Name].Quantity += itemSlot.Quantity;
            return;
        }
        if (Container.Count == MaxNumberInventory) return;

        Container.Add(itemSlot.Item.Name, itemSlot);
    }

    public void RemoveItem(ItemSlot itemSlot)
    {
        Container[itemSlot.Item.Name].Quantity--;
        if (itemSlot.Quantity == 1)
        {
            Container.Remove(itemSlot.Item.Name);
        }
    }
}
