using UnityEngine;
using System;

[CreateAssetMenu(fileName = "new Equipment Item", menuName = "Scriptable Object/Equipment Item")]
public class EquipmentItem : BaseItem
{
    public EquipmentTypes EquipmentType;
    
    private void Awake()
    {
        Type = ItemTypes.Equipment;
    }
}

public enum EquipmentTypes{
    Helmet,
    Armor,
    Pants,
    Shoes,
    Gloves,
    Weapon
}