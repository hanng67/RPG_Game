using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour
{
    public Image ItemImage;
    public Text TxtQuantity;

    private ItemSlot itemSlot;

    public void UpdateInfo(ItemSlot _itemSlot)
    {
        itemSlot = _itemSlot;
        if(itemSlot.Item == null){
            ItemImage.enabled = false;
            TxtQuantity.text = "";
            return;
        }

        ItemImage.enabled = true;
        ItemImage.sprite = itemSlot.Item.Icon;
        TxtQuantity.text = itemSlot.Quantity > 1 ? itemSlot.Quantity.ToString() : "";
    }

    public void OnMouseEnter()
    {
        if(itemSlot.Item == null) return;

        Events.EventMouseStartHoverItem.Invoke(itemSlot.Item.GetInfoDisplayText());
    }

    public void OnMouseExit()
    {
        if(itemSlot.Item == null) return;
        
        Events.EventMouseEndHoverItem.Invoke();
    }
}
