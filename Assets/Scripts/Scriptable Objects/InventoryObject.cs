using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Inventory Object", menuName = "Scriptable Object/Inventory")]
public class InventoryObject : ScriptableObject
{
    public Dictionary<string, ItemInfo> Container = new Dictionary<string, ItemInfo>();
    public List<ItemInfo> Container1 = new List<ItemInfo>();
    private int maxNumberInventory;

    private void Awake()
    {
        maxNumberInventory = 40;
    }

    public void AddItem(ItemInfo item)
    {
        if (Container.ContainsKey(item.Stats.Name))
        {
            Container[item.Stats.Name].Amount += item.Amount;
            return;
        }
        if (Container.Count == maxNumberInventory) return;

        Container.Add(item.Stats.Name, item);
        Container1.Add(item);
    }

    public void RemoveItem(ItemInfo item)
    {
        Container[item.Stats.Name].Amount--;
        if (item.Amount == 1)
        {
            Container.Remove(item.Stats.Name);
        }
    }
}
