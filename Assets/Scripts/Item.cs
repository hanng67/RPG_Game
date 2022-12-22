using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;

    [Header("Item Details")]
    public string itemName;
    [TextArea(5, 1)]
    public string description;
    public int value;
    public Sprite itemSprite;
    [Space]
    public int amountToChange;
    public bool affectHP, affectMP, affectStr;

    [Header("Weapon/Armor Details")]
    public int weaponStrength;

    public int armorStrength;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Use(int charToUseOn)
    {
        CharStats selectedChar = GameManager.instance.playerStats[charToUseOn];
        IsUseItem(ref selectedChar);
        IsEquipWeapon(ref selectedChar);
        IsEquipArmor(ref selectedChar);
        GameManager.instance.RemoveItem(itemName);
    }

    private void IsUseItem(ref CharStats selectedChar)
    {
        if (!isItem) return;

        if (affectHP)
        {
            selectedChar.currentHP += value;
            if (selectedChar.currentHP > selectedChar.maxHP) selectedChar.currentHP = selectedChar.maxHP;
        }
        else if (affectMP)
        {
            selectedChar.currentMP += value;
            if (selectedChar.currentMP > selectedChar.maxMP) selectedChar.currentMP = selectedChar.maxMP;
        }
    }

    private void IsEquipWeapon(ref CharStats selectedChar)
    {
        if (!isWeapon) return;

        GameManager.instance.AddItem(selectedChar.equippedWpn);
        selectedChar.equippedWpn = itemName;
        selectedChar.wpnPwr = weaponStrength;
    }

    private void IsEquipArmor(ref CharStats selectedChar)
    {
        if (!isArmor) return;

        GameManager.instance.AddItem(selectedChar.equippedArmr);
        selectedChar.equippedArmr = itemName;
        selectedChar.armrPwr = armorStrength;
    }
}
