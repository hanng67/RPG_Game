using UnityEngine;

public class Rarity
{
    public RarityName Name;
    public RarityColour TextColour;
    public Rarity(RarityName name, RarityColour textColour)
    {
        this.Name = name;
        this.TextColour = textColour;
    } 
}

public enum RarityName
{
    Normal,
    Rare,
    Epic,
    Unique,
    Legendary,
    Mythic,
}

public enum RarityColour
{
    white,
    cyan,
    purple,
    teal,
    orange,
    yellow,
}