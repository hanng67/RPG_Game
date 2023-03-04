using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : UIBaseSlot
{
    [SerializeField] private Text TxtQuantity;

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

    public override void OnDisable()
    {
        base.OnDisable();
        toggle.isOn = false;
    }

    public override void UpdateInfo(ItemSlot itemSlot)
    {
        base.UpdateInfo(itemSlot);
        TxtQuantity.text = itemSlot.Quantity > 1 ? itemSlot.Quantity.ToString() : "";
    }

    public override void ResetInfo()
    {
        base.ResetInfo();
        TxtQuantity.text = "";
    }

    public void OnSelect()
    {
        if(!toggle.isOn) return;
        
        Events.EventSelectItem.Invoke(itemSlot);
    }
}
