using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string CharName;
    public int PlayerLevel = 1;
    public int CurrentExp;
    public int[] ExpToNextLevel;
    private int maxLevel = 100;
    private int baseEXP = 1000;

    public int CurrentHP;
    public int MaxHP = 100;
    public int CurrentMP;
    public int MaxMP = 30;
    public int[] MpLvlBonus;
    public int Strengh;
    public int Defence;
    public int WpnPwr;
    public int ArmrPwr;
    public string EquippedWpn;
    public string EquippedArmr;

    public Sprite CharImage;

    // Start is called before the first frame update
    void Start()
    {
        ExpToNextLevel = new int[maxLevel];
        MpLvlBonus = new int[maxLevel];
        ExpToNextLevel[1] = baseEXP;
        for (int i=2; i < maxLevel; i++)
        {
            ExpToNextLevel[i] = Mathf.FloorToInt(ExpToNextLevel[i - 1] * 1.05f);

            if(i%2 == 0)
            {
                MpLvlBonus[i] = i * 10;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddExp(int expToAdd)
    {
        CurrentExp += expToAdd;

        if (PlayerLevel < maxLevel)
        {
            if (CurrentExp > ExpToNextLevel[PlayerLevel])
            {
                CurrentExp -= ExpToNextLevel[PlayerLevel];
                PlayerLevel++;
            }

            //determine whether to add to str of def based on odd or even
            if (PlayerLevel % 2 == 0)
            {
                Strengh++;
            }
            else
            {
                Defence++;
            }

            MaxHP = Mathf.FloorToInt(MaxHP * 1.05f);
            CurrentHP = MaxHP;

            MaxMP += MpLvlBonus[PlayerLevel];
            CurrentMP = MaxMP;
        }

        if(PlayerLevel >= maxLevel)
        {
            CurrentExp = 0;
        }
    }
}
