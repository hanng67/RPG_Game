using System;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public BaseItem Item;
    public int Quantity = 1;

    public ItemSlot() { }

    public ItemSlot(BaseItem item, int quantity)
    {
        this.Item = item;
        this.Quantity = quantity;
    }
}