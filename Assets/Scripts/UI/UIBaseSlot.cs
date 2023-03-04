using UnityEngine;
using UnityEngine.UI;

public abstract class UIBaseSlot : MonoBehaviour
{
    [SerializeField] private Image ItemImage;
    protected ItemSlot itemSlot;

    public virtual void OnDisable()
    {
        OnMouseExit();
    }

    public virtual void UpdateInfo(ItemSlot itemSlot)
    {
        this.itemSlot = itemSlot;
        ItemImage.enabled = true;
        ItemImage.sprite = itemSlot.Item.Icon;
    }

    public virtual void ResetInfo()
    {
        itemSlot = new ItemSlot();
        ItemImage.enabled = false;
        ItemImage.sprite = null;
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
}