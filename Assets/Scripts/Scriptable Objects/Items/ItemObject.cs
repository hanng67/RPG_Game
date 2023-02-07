using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item Object", menuName = "Scriptable Object/Item")]
public class ItemObject : ScriptableObject
{
    public string Name;
    public GameDefine.ItemTypes Type;
    public Sprite Sprite;
    [TextArea(15, 20)]
    public string Description;
    public ItemBuff[] Buffs;
    public int Value;
}

[System.Serializable]
public class ItemInfo
{
    public ItemObject Stats;
    public int Amount = 1;

    ItemInfo()
    {
        // if (Stats.Type != GameDefine.ItemTypes.Potion)
        // {
        //     foreach (var buff in Stats.Buffs)
        //     {
        //         buff.GenerateValue();
        //     }
        // }
    }
}

[System.Serializable]
public class ItemBuff
{
    public GameDefine.Attributes Attributes;
    // public int MinValue;
    // public int MaxValue;
    public int Value;

    // public void GenerateValue()
    // {
    //     Value = Random.Range(MinValue, MaxValue);
    // }
}