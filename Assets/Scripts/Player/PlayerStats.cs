using System;
using GameDefine;

[Serializable]
public class PlayerStats
{
    // Health_Restore = 0
    // Mana_Restore = 1
    // Health = 2
    // Mana = 3
    // Exp = 4
    // Attack = 5
    // Defence = 6
    // Agility = 7
    // Strength = 8
    // Intelligent = 9
    // Stamina = 10
    // Count
    public Stat[] Stats = new Stat[(int)Attributes.Count]
    {
        new Stat("Current_HP", 100),
        new Stat("Current_MP", 30),
        new Stat("Max_HP", 100),
        new Stat("Max_MP", 30),
        new Stat("Exp", 0),
        new Stat("Level", 1),
        new Stat("Attack", 5),
        new Stat("Defence", 5),
        new Stat("Agility", 5),
        new Stat("Strength", 5),
        new Stat("Intelligent", 5),
        new Stat("Stamina", 5),
    };

    public int this[Attributes attribute]
    {
        get { return Stats[(int)attribute].Value; }
        set { Stats[(int)attribute].Value = value; }
    }


    [Serializable]
    public struct Stat
    {
        public string Name;
        public int Value;

        public Stat(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}