using UnityEngine;
using UnityEngine.UI;

public class UIEquipmentSlot : UIBaseSlot
{
    [SerializeField] private EquipmentTypes equipmentType;
    [SerializeField] private Image defaultItemImage;

    public void Init(EquipmentTypes equipmentType, Sprite defaultSprite){
        this.equipmentType = equipmentType;
        defaultItemImage.sprite = defaultSprite;
    }

    public override void UpdateInfo(ItemSlot itemSlot)
    {
        base.UpdateInfo(itemSlot);
        defaultItemImage.enabled = false;
    }

    public override void ResetInfo()
    {
        base.ResetInfo();
        defaultItemImage.enabled = true;
    }
}