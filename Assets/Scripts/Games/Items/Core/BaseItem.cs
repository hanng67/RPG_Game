using UnityEngine;
using System;
using System.Text;
using GameDefine;

[CreateAssetMenu(fileName = "new Item", menuName = "Scriptable Object/Item")]
public class BaseItem : ScriptableObject
{
    [Header("Basic Info")]
    public string Name;
    public Sprite Icon;
    public ItemTypes Type;
    [TextArea(15, 20)]
    public string Description;

    [Header("Item Stats")]
    [SerializeField] private RarityName rarity;
    public Rarity Rarity => new Rarity(rarity, (RarityColour)((int)rarity));
    public ItemBuff[] Buffs;
    [Min(0)] public int SellPrice = 0;
    [Min(1)] public int MaxStack = 1;

    public string GetInfoDisplayText()
    {
        StringBuilder builder = new StringBuilder();
        
        builder.Append($"<size=35><color={Rarity.TextColour}>{Name}</color></size>").AppendLine();
        builder.Append($"<color=olive>{Rarity.Name}</color>").AppendLine();
        builder.Append($"<color={Rarity.TextColour}>{Description}</color>").AppendLine();
        builder.Append("Sell Price: ").Append(SellPrice).Append(" Gold");

        return builder.ToString();
    }
}

public enum ItemTypes
{
    Potion,
    Equipment
}

[Serializable]
public struct ItemBuff
{
    public Attributes Attributes;
    // public int MinValue;
    // public int MaxValue;
    public int Value;

    // public void GenerateValue()
    // {
    //     Value = Random.Range(MinValue, MaxValue);
    // }
}