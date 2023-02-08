using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClone : MonoBehaviour
{
    [Header("Item Type")]
    public bool IsItem;
    public bool IsWeapon;
    public bool IsArmor;

    [Header("Item Details")]
    public string ItemName;
    [TextArea(5, 1)]
    public string Description;
    public int Value;
    public Sprite ItemSprite;
    [Space]
    public int AmountToChange;
    public bool AffectHP, AffectMP, AffectStr;

    [Header("Weapon/Armor Details")]
    public int weaponStrength;

    public int armorStrength;

    public void Use(int charToUseOn)
    {
        CharStats selectedChar = GameManager.Instance.playerStats[charToUseOn];
        IsUseItem(ref selectedChar);
        IsEquipWeapon(ref selectedChar);
        IsEquipArmor(ref selectedChar);
        // GameManager.Instance.RemoveItem(ItemName);
    }

    private void IsUseItem(ref CharStats selectedChar)
    {
        if (!IsItem) return;

        if (AffectHP)
        {
            selectedChar.CurrentHP += Value;
            if (selectedChar.CurrentHP > selectedChar.MaxHP) selectedChar.CurrentHP = selectedChar.MaxHP;
        }
        else if (AffectMP)
        {
            selectedChar.CurrentMP += Value;
            if (selectedChar.CurrentMP > selectedChar.MaxMP) selectedChar.CurrentMP = selectedChar.MaxMP;
        }
    }

    private void IsEquipWeapon(ref CharStats selectedChar)
    {
        if (!IsWeapon) return;

        // GameManager.Instance.AddItem(selectedChar.EquippedWpn);
        selectedChar.EquippedWpn = ItemName;
        selectedChar.WpnPwr = weaponStrength;
    }

    private void IsEquipArmor(ref CharStats selectedChar)
    {
        if (!IsArmor) return;

        // GameManager.Instance.AddItem(selectedChar.EquippedArmr);
        selectedChar.EquippedArmr = ItemName;
        selectedChar.ArmrPwr = armorStrength;
    }
}
