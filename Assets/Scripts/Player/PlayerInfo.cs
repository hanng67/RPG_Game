using UnityEngine;
using GameDefine;

public class PlayerInfo : MonoBehaviour
{
    public string Name;
    public Sprite Icon;
    public int Level = 1;

    public PlayerStats Stats = new PlayerStats();

    private int[] ExpToNextLevel;
    private int maxLevel = 100;
    private int baseEXP = 1000;
    private int[] MpLvlBonus;

    private void Start()
    {
        ExpToNextLevel = new int[maxLevel];
        MpLvlBonus = new int[maxLevel];
        ExpToNextLevel[1] = baseEXP;
        for (int i = 2; i < maxLevel; i++)
        {
            ExpToNextLevel[i] = Mathf.FloorToInt(ExpToNextLevel[i - 1] * 1.05f);

            if (i % 2 == 0)
            {
                MpLvlBonus[i] = i * 10;
            }
        }
    }

    public void AddExp(int expToAdd)
    {
        Stats[Attributes.Exp] += expToAdd;

        if (Stats[Attributes.Level] < maxLevel)
        {
            if (Stats[Attributes.Exp] > ExpToNextLevel[Stats[Attributes.Level]])
            {
                Stats[Attributes.Exp] -= ExpToNextLevel[Stats[Attributes.Level]];
                Stats[Attributes.Level]++;
            }

            //determine whether to add to str of def based on odd or even
            if (Stats[Attributes.Level] % 2 == 0)
            {
                Stats[Attributes.Attack]++;
            }
            else
            {
                Stats[Attributes.Defence]++;
            }

            Stats[Attributes.Health] = Mathf.FloorToInt(Stats[Attributes.Health] * 1.05f);
            Stats[Attributes.Health_Restore] = Stats[Attributes.Health];

            Stats[Attributes.Mana] += MpLvlBonus[Stats[Attributes.Level]];
            Stats[Attributes.Mana_Restore] = Stats[Attributes.Mana];
        }

        if (Stats[Attributes.Level] >= maxLevel)
        {
            Stats[Attributes.Exp] = 0;
        }
    }
}
