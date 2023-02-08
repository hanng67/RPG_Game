using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Inventory Object", menuName = "Scriptable Object/Inventory")]
public class InventoryObject : ScriptableObject
{
    public Dictionary<string, ItemInfo> Container = new Dictionary<string, ItemInfo>();
    public int MaxNumberInventory { get; private set; }

    private void Awake()
    {
        MaxNumberInventory = 40;
    }

    public void AddItem(ItemInfo item)
    {
        if (Container.ContainsKey(item.Stats.Name))
        {
            Container[item.Stats.Name].Amount += item.Amount;
            return;
        }
        if (Container.Count == MaxNumberInventory) return;

        Container.Add(item.Stats.Name, item);
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
