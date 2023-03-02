using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour
{
    public Image ItemImage;
    public Text TxtQuantity;

    private ItemSlot itemSlot;
    private Toggle toggle;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        toggle.group = GetComponentInParent<ToggleGroup>();
    }

    private void Update()
    {
        toggle.interactable = (itemSlot.Item != null);
    }

    private void OnDisable()
    {
        OnMouseExit();
        toggle.isOn = false;
    }

    public void UpdateInfo(ItemSlot _itemSlot)
    {
        itemSlot = _itemSlot;
        if (itemSlot.Item == null) return;

        ItemImage.enabled = true;
        ItemImage.sprite = itemSlot.Item.Icon;
        TxtQuantity.text = itemSlot.Quantity > 1 ? itemSlot.Quantity.ToString() : "";
    }

    public void ResetInfo()
    {
        itemSlot = new ItemSlot();
        ItemImage.enabled = false;
        TxtQuantity.text = "";
    }

    public void OnMouseEnter()
    {
        if (itemSlot.Item == null) return;

        Events.EventMouseStartHoverItem.Invoke(itemSlot.Item.GetInfoDisplayText());
    }

    public void OnMouseExit()
    {
        if (itemSlot.Item == null) return;

        Events.EventMouseEndHoverItem.Invoke();
    }

    public void OnSelect()
    {
        if(!toggle.isOn) return;
        
        Events.EventSelectItem.Invoke(itemSlot);
    }
}
