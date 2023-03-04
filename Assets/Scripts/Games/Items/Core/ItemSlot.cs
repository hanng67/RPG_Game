using System;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public BaseItem Item = null;
    public int Quantity = 0;

    public ItemSlot(BaseItem item = null)
    {
        if(!item) return;

        this.Item = item;
        this.Quantity = 1;
    }

    public ItemSlot(BaseItem item, int quantity)
    {
        this.Item = item;
        this.Quantity = quantity;
    }

    public void Use(){}
}